using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerEquiped
{
    public BaseItem Weapon;
    public BaseItem head;
    public BaseItem shield;
    public BaseItem cloth;
    public BaseItem horse;
    public BaseItem accessories;
    public BaseItem MagicGoods;
}



public class GM : MonoBehaviour
{
    private bool BattleEventLock = false;

    public static event Action OnStartBattle;
    public static event Action OnEndBattle;
    public static bool isBattleMode = false;

    public static Locale locale = Locale.李靖府邸入口;


   
    public static Dictionary<string, BaseAbility> abilitys = new Dictionary<string, BaseAbility>(); // give monster some ability to do something.
    public static bool hasRecord = false;

    //怪物战斗系统
    public static List<BaseMonster> baseMonstersInfo = new List<BaseMonster>();
    public static List<BaseHero> Heroes = new List<BaseHero>();


    public static bool LoadRecord(int which)
    {
        if (false)
        {

        }
        return false;
    }
    // Use this for initialization
    void Start()
    {
        

        Screen.SetResolution(1920, 1080, false, 120);
        DontDestroyOnLoad(gameObject);
        Debug.Log("GM Start");
        ResetHeroesId();
      //  playerEquipment();



    }
    
    /// <summary>
    /// Resets the heroes identifier. 因为没有固定id.
    /// 增加角色的时候也要调用
    /// </summary>
    public static void ResetHeroesId()
    {
        Heroes = Heroes.OrderBy(prop => prop.id).ToList();
        for (int i = 0; i < Heroes.Count; i++)
        {
            Heroes[i].id = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBattleMode)
        { //in Battle
            if (OnStartBattle != null && BattleEventLock == false)
            {
                BattleEventLock = true;
                OnStartBattle();
            }
        }
        else
        {//in travel
            if (OnEndBattle != null && BattleEventLock == true)
            {
                BattleEventLock = false;
                OnEndBattle();
            }

        }
    }


 

}



public enum Stage
{
    Safe = 0,
    Well1 = 1,
    Well2 = 2,
    Well3 = 3,
}


 
public class Health{
   public int HP;
   public int MP;
  public  int SP;
}

