using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    Common,
    Spell,
    Throw,
    Bag,
    Attack
}
public enum SkillType{
    Offensive,
    Health,
    Buff,

}
public enum Skills
{
    Attack = 10000,
    EleAttack = 10010,
    Fire=20000,
    Freeze=20001
 
}

 

public class BaseAbility {
    
  
    public static  BaseAbility GetAbility(Skills s){
        return BattleSystem.abilitys[(int)s];
    }
    public BoradProperty boradProperty;
    /// <summary>
    /// 当多个怪兽被攻击时候 需要有一个下一轮的间隔等待
    /// </summary>
    public float mutilTargetTimeSpan;  
    /// <summary>
    /// 技能靠近目时的持续时间
    /// </summary>
    public float touchingDuration;
    /// <summary>
    /// 技能飞行时间
    /// </summary>
    public float FlyingDuration = 1;
    /// <summary>
    /// 吟唱时间
    /// </summary>
    public float NenDuration;
    /// <summary>
    /// 技能持续飞行直到靠近目标
    /// </summary>
    public bool AlwaysFyingWithoutTimeLimited = false;
    /// <summary>
    /// 如果是立即释放的魔法 持续时间不加载这里的时间 会直接读取魔法的持续时间
    /// </summary> 
    public bool immediately = false;
    public bool toSelf = false;
    public string abilityName;
    public string abilityDescription;
    public static int id;
    public int cost;
    public float powerRate;
    public const int targetCount = 1;
    public int targetExtra;
    /// <summary>
    /// 打击次数
    /// </summary>
    public int hitTimes = 1;
    public AbilityType type;
    public SkillType skillType;
    public List<BaseAbility> subAbilities = new List<BaseAbility>();
    public PanelType PanelType;
    public List<BaseEffect> effect = new List<BaseEffect>();
    public GameObject entity;
    public int level = 1;

    public Sprite GetIcon(){
        if(entity!=null){
            return entity.GetComponent<Carry>().SpellIcon;
        }
        return null;
    }
     
}






