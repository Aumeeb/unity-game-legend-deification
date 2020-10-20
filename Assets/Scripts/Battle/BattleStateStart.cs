using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




public enum StatType
{
    stamina,
    endurance,
    intellect,
    strangth,
    overpower,
    mastery,
    luck,
    charisma
}
public class BattleStateStart :MonoBehaviour  {
    
   
    BaseMonster enemy;
    BaseHero hero;
    bool isCreating = false;
   
   
   
  
        
    public void setBattlePosition()
    {
        //camera.transform.localPosition = new Vector3(0, 0.22f, -1);
        //if (baseHeroes.Count == 1)
        //{
        //    baseHeroes[0].entity.transform.position = Vector3.zero;
        //}
    }


    void whoIsFirst(int rate){
        if(rate>Random.Range(1, 100)){
            CombatStateMachine.isHeroesTurn = true;
          

        }else{
            CombatStateMachine.isHeroesTurn = false;
           
        }
    }


    public void prepareBattle(){
            CombatStateMachine.whoIsNext = 0;
            Debug.Log("正在创建怪物");
            isCreating = true;
            CombatStateMachine.state = BattleStateType.Processing;


            whoIsFirst(100);
            createEnemy(Random.Range(BattleSystem.MinEnemyCount, BattleSystem.MaxEnemyCount));
            createHeroes();

            if (CombatStateMachine.isHeroesTurn)
            {
                CombatStateMachine.state = BattleStateType.HeroesChoise;
            }
            else
            {
                CombatStateMachine.state = BattleStateType.EnemiesChoise;
            }
          

       
       
    }
    

    void createEnemy(int count){

        List<BattleSlot> field = new List<BattleSlot>();
        int row = 3;
        int col = 12;
        int size = row * col;

        Vector2 begin = new Vector2(-17, 9);
        Vector2 space = new Vector2(3f, 3);

        Vector2 v2 = begin;
       

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                var eachone = new BattleSlot();
                var final = new Vector2(begin.x + space.x * j, begin.y - space.y * i);
                field.Add(new BattleSlot() { isEmpty = true, v2 = final });                    
            }
        }



        for (int i = 0; i < count; i++)
        {

            List<BattleSlot> available = field.Where(prop => prop.isEmpty).ToList();
            int emptyIndex = Random.Range(0, available.Count);
            available[emptyIndex].isEmpty = false;


            int randomIndexChoise = Random.Range(0, BattleSystem.Monsters.Count);
            var perfabs = BattleSystem.Monsters[randomIndexChoise];
            var copyMonster= Object.Instantiate(perfabs, available[emptyIndex].v2, Quaternion.identity);
            EmenyDecription emenyDecription = copyMonster.GetComponent<EmenyDecription>();

            enemy = new BaseMonster();
            int abilityIndex = (int)emenyDecription.attack;
            var attackAbt = BattleSystem.abilitys[abilityIndex];
            enemy.MonsterAbilities.Add(attackAbt);
           

            enemy.entity = copyMonster;
            copyMonster.name = emenyDecription.NickName + "(" + i + ")";
            enemy.ThingName = emenyDecription.NickName + "(" + i + ")";
            enemy.Level = emenyDecription.level;
            enemy.FinalPropertyBoard += emenyDecription.State;
            enemy.id = i;
            enemy.FinalPropertyBoard.CalcBoardProperty();
            enemy.hp = enemy.FinalPropertyBoard.MaxHP;
            enemy.mp = enemy.FinalPropertyBoard.MaxMP;
            GM.baseMonstersInfo.Add(enemy);

            GM.baseMonstersInfo = GM.baseMonstersInfo.OrderBy(mn => mn.id).ToList(); //可能有bug

        }
    }

    void createHeroes(){
        float xSpace = 3;

         Vector3 position = new Vector3(0, 0, -1);
        int count = GM.Heroes.Count;
        float totalSpaceX = xSpace * (count - 1);

        if(count==1){
            GM.Heroes[0].entity.GetComponent<Character>().replace(position);
            GM.Heroes[0].entity.GetComponent<Player>().BattleMode();
            GM.Heroes[0].entity.GetComponent<Player>().lastPosition = position;
            GM.Heroes[0].entity.GetComponent<Shake>().prePosition = position;
            return;

        }

            xSpace = totalSpaceX / count;
          
        if (count % 2 == 1)
        {
            // even
            int middle = (count - 1) / 2;
            GM.Heroes[middle - 1].entity.GetComponent<Character>().replace(new Vector3(0, 0, -1));
        }
        else
        {
            int middle = count / 2;
            for (int i = 0; i < count; i++)
            {
                var pos = new Vector3(0, 0, -1);
                if (i + 1 <= middle)
                    position.x += -xSpace * (i + 1);
                else
                    position.x += xSpace * (i + 1);
                
                GM.Heroes[i].entity.GetComponent<Character>().replace(position);
                GM.Heroes[i].entity.GetComponent<Player>().BattleMode();
                GM.Heroes[i].entity.GetComponent<Player>().lastPosition = position;
                GM.Heroes[i].entity.GetComponent<Shake>().prePosition = position;
            }

        }
     
    }
}

public class BattleSlot{
    public Vector2 v2;
    public  bool isEmpty;
}