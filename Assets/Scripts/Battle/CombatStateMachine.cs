using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;
/*
*  
1. 设置战斗状态机为 idle 
2. start 战斗准备 计算自己和敌人的数量 保存下来 根据角色的luck 进行攻击排序      
3. heroRound  绘制UI 行动的角色 头上有一个小手。。。进行提示 ，  记录攻击状态  
4  heroAttack 进入打击状态 for 循环 1 判断  check调整下一轮攻击的人数，或者检测胜利与否  如果第二个角色攻击的角色死亡了 。 就自动寻找下一个或者的对象
5  
*/
using System.Security.Permissions;
using System.Runtime.InteropServices.ComTypes;



public class RoundRecord
{

   
    public int manaCast=0;
    public int healthCast = 0;
    public bool canAnimation = false;
    public bool isFinished = false;
    public string Name;
    public int round = 0;
    public List<BaseAbility> abilityList = new List<BaseAbility>();
    public BaseThing I;
    public List<int> You = new List<int>();
    public List<DamageInfoForAnimation> damageInfos = new List<DamageInfoForAnimation>();
    public RoundRecord(BaseThing i, List<int> you, BaseAbility basea)
    {
        I = i;
        You = you;
        I.UsedAbilityThisRound = basea;
        Name = i.ThingName;
    }
    public bool EnmeyAllDeath = false;
    public bool HeroesAllDeath = false;
    public RoundRecord(BaseThing i, List<int> you, BaseAbility basea, List<BaseAbility> items)
    {
        I = i;
        You = you;
        I.UsedAbilityThisRound = basea;
        abilityList = items;
        Name = i.ThingName;

    }

}

/// <summary>
/// 存储一个伤害值的数据,以用于以后播放动画或者杀死怪物的依据 在 计算伤害的时候添加
/// </summary>
public class DamageInfoForAnimation{
    public   int normalDamage;
    public  int trueDamage;
    public int totalDamage;
    public int hitTimes = 1;
    public bool isAlive = true;
}


enum DamageType
{ 
    While,
    Yellow,
}

public class CombatStateMachine : MonoBehaviour {


    int xxxxxx = 0;
    public static event Action OnEnemyFinished;
    public static event Action OnManaChanged;
    public static event Action OnComeBacking;
    public static event Action OnHealthChanged;
    public static List<BaseThing> WhoIscharger = new List<BaseThing>(); // Charger list mean this 
    public static List<BaseThing> WhoIsufferer = new List<BaseThing>(); // sufferer list means this time how many emeny will be attack
    public static List<RoundRecord> roundRecords = new List<RoundRecord>();
    public static List<BaseMonster> readyForRob = new List<BaseMonster>();
   
    CalculateDamage calculateDamage = new CalculateDamage();
    
    public static int whoIsNext = 0;  //WhoIscharger's index 
    public int round = 1;
    private GameObject canvas;

    /// <summary>
    /// This is heroes round.
    /// </summary>
    public static bool isHeroesTurn = true;
    
    public static bool isFinished =false;
   
    public static bool inQuque = true;
    public static float awaits = 1f;  // each action of current round how much time will await;
    public static bool check = false;
    public static BattleStateType state = BattleStateType.Start;   // the battle state f
	





	void Start () {
        DontDestroyOnLoad(gameObject);
        canvas = GameObject.Find("Canvas");
	}
	

	void Update () {

        if(GM.isBattleMode){
            Debug.Log(state);
//            Debug.Log("当前是玩家么 " + isHeroesTurn);
            switch (state)
            {
                case BattleStateType.Idle:
                    break;
                case BattleStateType.HeroesChoise:
                    //see Class Battle GUI 
                    break;
                case BattleStateType.Buff:
                    break;
                case BattleStateType.CalculateDamage:
                    calculateDamage.CalcDamage();
                    break;
                case BattleStateType.HeroesEffect:                           
                        PlayHeroesAnimtion();
                    break;                  
                case BattleStateType.MonsterEffect: 
                        PlayMonsterAnimaton();
                    break;               
                case BattleStateType.EnemiesChoise:
                    calculateDamage.CalcDamage();
                    break;   
                case BattleStateType.Win:
                    break;
                case BattleStateType.ComeBack:
                    if (OnComeBacking!=null)
                    {
                        OnComeBacking();
                    }
                   
                    StartCoroutine(BattleSystem.ComeToTrap(1));

                    break;
                   
            }
        }

	}
   

 

   


    public static bool NextHero(){
        try
        {
            whoIsNext++;
            var has = GM.Heroes[whoIsNext];
            return true;
        }
        catch 
        {
            return false;
        }
    }
    /// <summary>
    /// 普通攻击模式 跳跃过程中的时间花费.
    /// </summary>
    float flyingTime = 1f;
    /// <summary>
    /// 队员切换下来一位攻击的时候等待时间.
    /// </summary>
    float turnNextoneTime = .5f;
    public void PlayHeroesAnimtion()
    {
        state = BattleStateType.Processing;
        if (round==1)
        {
            readyForRob = GM.baseMonstersInfo.ToList();
        }
        Debug.Log(xxxxxx++);
        Debug.Log("进入了英雄动画时间...");

        roundRecords[roundRecords.Count - 1].isFinished = true; //设置一个人标记为最后一次行动 然后切换 对方攻击

        float timeLine = 0;
        timeLine += turnNextoneTime;  //第一回合等待一秒  //作为调整的延迟
        for (int i = 0; i < roundRecords.Count; i++)
        {

            RoundRecord record = roundRecords[i];
            BaseAbility used = record.I.UsedAbilityThisRound;

//            Debug.Log(record.Name);
            if (record.canAnimation && used.type == AbilityType.Attack)
            {
                StartCoroutine(FlyToMonster(record, timeLine));
                timeLine += used.touchingDuration * used.hitTimes + flyingTime ; //+ turnNextoneTime;
                continue;
            }
            if (record.I.UsedAbilityThisRound.type == AbilityType.Spell)
            {
                record.I.mp -= record.manaCast;  //减去魔法

                if (used.immediately) //cast spell immediately
                {               
                    for (int index = 0; index < record.You.Count; index++)
                    {
                        StartCoroutine(CastImmediately(record, index, timeLine + index * used.mutilTargetTimeSpan));
                    }

                    timeLine += ((record.You.Count-1) * used.mutilTargetTimeSpan) + used.touchingDuration; //+turnNextoneTime

                }//有飞行时间
                else
                {
                                                     
                    for (int index = 0; index < record.You.Count; index++)
                    {
                        StartCoroutine(CastTrace(record, index, timeLine + index * used.mutilTargetTimeSpan));
                    }
                    timeLine += ((record.You.Count-1) * used.mutilTargetTimeSpan) + used.FlyingDuration;

                }
            }

            timeLine += turnNextoneTime;
        }

        timeLine = 0;

    }

    #region heroCast spell
    IEnumerator CastImmediately( RoundRecord record,int index, float delay){
        yield return new WaitForSeconds(delay);
        try
        {
          
           
            CastSuddenly cast = record.I.UsedAbilityThisRound.entity.GetComponent<CastSuddenly>();
            BaseMonster monster = GM.baseMonstersInfo.Find(prop => prop.id == record.You[index]);
            cast.Create(record.I.UsedAbilityThisRound.entity, monster.entity.transform.position);
            DamagePopup(record, monster, index, DamageType.Yellow);
            var shake = monster.entity.GetComponent<Shake>();
            shake.Shocking(record.I.UsedAbilityThisRound.touchingDuration);


            monster.hp -= record.damageInfos[index].normalDamage; //reduce hero health point
            
            if (monster.hp <= 0){
                monster.entity.GetComponent<Kill>().You();
            }
               

            Debug.Log(record.Name + " index " + index + " delay " + delay + " monster : hp is " + monster.hp );

            if (record.You.Count - 1 == index)   //因为是 技能挨个播放 所以我需要在最后一个动画播放完毕的时候再做校验 
                Checking(record);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
      

    }

    IEnumerator CastTrace(RoundRecord record, int index, float delay){
        yield return new WaitForSeconds(delay);
//        Debug.Log("CastTrace +++");
        Cast cast = record.I.UsedAbilityThisRound.entity.GetComponent<Cast>();
        BaseMonster monster = GM.baseMonstersInfo.Find(prop => prop.id == record.You[index]);

        GameObject magicObject = cast.Create(monster.entity.transform.position, record.I.entity.transform.position);
        magicObject.GetComponent<Cast>().hitTarget = monster.entity.transform.position;

       
        StartCoroutine(CastTracing(record, index, record.I.UsedAbilityThisRound.FlyingDuration,magicObject));
       
       
    }

    IEnumerator CastTracing(RoundRecord record, int index, float delay,GameObject skillObject){
 
        yield return new WaitForSeconds(delay);

        Destroy(skillObject);

        BaseMonster monster = GM.baseMonstersInfo.Find(prop => prop.id == record.You[index]);

        var shake = monster.entity.GetComponent<Shake>();
        shake.Shocking(record.I.UsedAbilityThisRound.touchingDuration);

        DamagePopup(record, monster, index, DamageType.Yellow);

        #region kl monster
        monster.hp -= record.damageInfos[index].totalDamage; //reduce monster health point
        if (monster.hp <= 0)
        {
            monster.entity.GetComponent<Kill>().You();

        }
        #endregion
       

               if (record.You.Count - 1 == index)   //因为是 技能挨个播放 所以我需要在最后一个动画播放完毕的时候再做校验 
                Checking(record);
        
    }
    #endregion

    #region hero attack



    IEnumerator FlyToMonster(RoundRecord record, float delay)
    {
        Debug.Log("will FlytoMonster ");
        yield return new WaitForSeconds(delay);
        Debug.Log("after FlytoMonster take" + delay);

        GameObject monster = GM.baseMonstersInfo.Find(prop=>prop.id == record.You[0]).entity;

        Vector3 heroStandPositionOnAttack = monster.transform.position;
        heroStandPositionOnAttack.y -= 1f;

        record.I.entity.GetComponent<Player>().FaceToUp();


        Vector3[] paths = new Vector3[3];

        paths[0] = record.I.entity.transform.position;  
        paths[2] = heroStandPositionOnAttack;
        paths[1] = new Vector3(paths[2].x / 3, 2f, 0);

       
        iTween.MoveTo(record.I.entity, iTween.Hash("path", paths, "movetopath", true,  "time", flyingTime, "easetype", iTween.EaseType.easeOutCubic));

       
        StartCoroutine(Hiting(record,flyingTime));
    }

    IEnumerator Hiting(RoundRecord record,float lastDelay){
        
        yield return new WaitForSeconds(lastDelay);

        CastSuddenly suddenCast = record.I.UsedAbilityThisRound.entity.GetComponent<CastSuddenly>();
        float hittingTime = record.I.UsedAbilityThisRound.touchingDuration * record.damageInfos[0].hitTimes;


       

        for (int i = 0; i < record.You.Count; i++)
        {
            Debug.Log("created hit stars");
            BaseMonster monster = GM.baseMonstersInfo.Find(prop => prop.id == record.You[i]);
                     
            DamagePopup(record, monster,i);
            var shake = monster.entity.GetComponent<Shake>();
            shake.Shocking(hittingTime);
            suddenCast.Create(record.I.UsedAbilityThisRound.entity, monster.entity.transform.position, hittingTime);


        }

        //算计连续击打的时间 然后等待
        StartCoroutine(HitingComeback(record, hittingTime));


    }
    private void DamagePopupFixed(RoundRecord record, BaseThing monster, int i, DamageType damageType = DamageType.While){
        DamagePopup(record, monster, i, damageType);
    }
    private void DamagePopup(RoundRecord record, BaseThing monster, int i,DamageType damageType = DamageType.While)
    {

        GameObject dmg = null;
        if(damageType ==    DamageType.Yellow){
            dmg= GameObject.Instantiate(monster.damagePopupYellow, monster.entity.transform.position, Quaternion.identity);
        }
        if(damageType== DamageType.While ){
            dmg= GameObject.Instantiate(monster.damagePopupWhite, monster.entity.transform.position, Quaternion.identity);
        }

        Vector2 screenPos = Camera.main.WorldToScreenPoint(monster.entity.transform.position);
//        Debug.Log(screenPos);
        //  Debug.Log(Screen.width + " " + Screen.height);

       

        dmg.GetComponent<Text>().text = record.damageInfos[i].normalDamage.ToString();
        dmg.transform.SetParent(canvas.transform);
        dmg.transform.position = screenPos;
    }
    IEnumerator HitingComeback(RoundRecord record, float wait)
    {
        
        yield return new WaitForSeconds(wait);

        var player = record.I.entity.GetComponent<Player>();
        player.replace(player.lastPosition);
        player.FaceToDown();

        int index = 0;
        foreach (var id in record.You)
        {
            var monster = GM.baseMonstersInfo.Find(p => p.id == id);

                
            #region Kill monster
            monster.hp -= record.damageInfos[index].totalDamage; //reduce monster health point
            if (monster.hp <= 0)
            {
                monster.entity.GetComponent<Kill>().You();

            }
            #endregion
            index++;      

        }


        Checking(record);

    }
    #endregion
 

   


    //-----------------------------------------------------播放怪物动画
    public void PlayMonsterAnimaton()
    {
        state = BattleStateType.Processing;
            roundRecords[roundRecords.Count - 1].isFinished = true; //设置一个人标记为最后一次行动 然后切换 对方攻击
            for (int i = 0; i < roundRecords.Count; i++)
            {
                var record = roundRecords[i];
                Debug.Log(record.Name);
                if (record.canAnimation)
                {
                    StartCoroutine(Shining(record, 1.5f + i ));  //等待一定时间
                }

            }
    }

    IEnumerator Shining(RoundRecord record, float delay)
    {
        
        yield return new WaitForSeconds(delay);
     



        GameObject effect = record.I.UsedAbilityThisRound.entity;



        for (int i = 0; i < record.You.Count; i++)
        {

            BaseHero hero = GM.Heroes.Find(prop => prop.id == record.You[i]);
            hero.hp -= record.damageInfos[i].normalDamage; //reduce hero health point


            var oneHero = GM.Heroes[record.You[i]];

            

            DamagePopup(record,oneHero, i);

            var shake = oneHero.entity.GetComponent<Shake>();
            shake.Shocking(0.2f);

            var myShake = record.I.entity.GetComponent<Shake>();
            myShake.isBattle = true;
            myShake.Shining(record.I.UsedAbilityThisRound.hitTimes* record.I.UsedAbilityThisRound.touchingDuration);


            var suddenCast = effect.GetComponent<CastSuddenly>();
            suddenCast.Create(effect, oneHero.entity.transform.position);
        }


        Checking(record);
   

       
    }


    void Checking(RoundRecord record){
        if(isHeroesTurn){
            if (record.EnmeyAllDeath)
            {
                state = BattleStateType.Win;
                var Allrewards= readyForRob.Select(p => p.entity.GetComponent<EmenyDecription>());

                StartCoroutine(RewardPopup.Rob(Allrewards.ToList(),2f));
                
               
                GM.baseMonstersInfo.Clear();
                roundRecords = new List<RoundRecord>();
                round = 1;
                return;
            }

            if (record.isFinished)
            {
               
                GM.baseMonstersInfo = GM.baseMonstersInfo.Where(prop => prop.isAlive).ToList();

                state = BattleStateType.EnemiesChoise;
                Debug.Log("剩余敌人数量" + GM.baseMonstersInfo.Count);
               

                isHeroesTurn = false;
               
            }
        }else
        {
            if (record.HeroesAllDeath)
            {
                state = BattleStateType.lose;
               
                isHeroesTurn = true;
                round = 1;
                return;
            }

            if (record.isFinished)
            {
                GM.Heroes = GM.Heroes.Where(prop => prop.isAlive).ToList();
                state = BattleStateType.HeroesChoise;
                round++;                   
                isHeroesTurn = true;
                
                whoIsNext = 0;
                if (OnEnemyFinished!= null)
                {
                    OnEnemyFinished();
                }
                


            }
        }
    }



}

