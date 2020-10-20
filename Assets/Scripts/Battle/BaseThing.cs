using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;




public static  class Extenstion{
    
    public static BoradProperty CalcBoardProperty(this BoradProperty b)
    {

        b.MaxHP = (int)Mathf.Round(b.strength * 1.2f);
        b.MaxMP = (int)Mathf.Round( b.intellect * 1.5f);

        if (b.strength + b.intellect > 0)
        {
            b.FinalDamage = Mathf.Round(b.AttackValue * (1 + (b.strength + b.intellect)/350f ));
        }
        if (b.luck > 0)
        {
            b.CritDamage = Mathf.Round(b.CritDamage * (b.luck/100f ));
        }
        return b;

    }
   
}


public interface IProperty{
    BoradProperty CalcBoardProperty();
}
[Serializable]
public class BoradProperty
{
    

   



  
    public static BoradProperty CreateNewBoardProperty(BoradProperty boardA, BoradProperty boardB){




        var board = new BoradProperty();
        board.AttackValue += boardA.AttackValue; //1
        board.DefendValue += boardA.DefendValue;//2
        board.MaxHP += boardA.MaxHP;//3
        board.MaxMP += boardA.MaxMP;
        board.HitCombo += boardA.HitCombo;
        board.CritDamage += boardA.CritDamage;
        board.ElementEnhance += boardA.ElementEnhance;

        board.PoisonDamage += boardA.PoisonDamage;
        board.PoisonRate += boardA.PoisonRate;

        board.FireDamage += boardA.FireDamage;
        board.FireRate += boardA.FireRate;

        board.IceRate += boardA.IceRate;
        board.IceDamage += boardA.IceDamage;

        board.StoneDamage += boardA.StoneDamage;
        board.StoneRate += boardA.StoneRate;

        board.EletricRate += boardA.EletricRate;
        board.EletricDamage += boardA.EletricDamage;
        board.EletricExtraDamage += boardA.EletricExtraDamage;

        board.BleedRate += boardA.BleedRate;
        board.BleedDamage += boardA.BleedDamage;
        board.BleedDur += boardA.BleedDur;

        board.strength += boardA.strength;
        board.magic += boardA.magic;
        board.luck += boardA.luck;
        board.intellect += boardA.intellect;
        board.gold += boardA.gold;



        board.AttackValue += boardB.AttackValue; //1
        board.DefendValue += boardB.DefendValue;//2
        board.MaxHP += boardB.MaxHP;//3
        board.MaxMP += boardB.MaxMP;
        board.HitCombo += boardB.HitCombo;
        board.CritDamage += boardB.CritDamage;
        board.ElementEnhance += boardB.ElementEnhance;

        board.PoisonDamage += boardB.PoisonDamage;
        board.PoisonRate += boardB.PoisonRate;

        board.FireDamage += boardB.FireDamage;
        board.FireRate += boardB.FireRate;

        board.IceRate += boardB.IceRate;
        board.IceDamage += boardB.IceDamage;

        board.StoneDamage += boardB.StoneDamage;
        board.StoneRate += boardB.StoneRate;

        board.EletricRate += boardB.EletricRate;
        board.EletricDamage += boardB.EletricDamage;
        board.EletricExtraDamage += boardB.EletricExtraDamage;

        board.BleedRate += boardB.BleedRate;
        board.BleedDamage += boardB.BleedDamage;
        board.BleedDur += boardB.BleedDur;

        board.strength += boardB.strength;
        board.magic += boardB.magic;
        board.luck += boardB.luck;
        board.intellect += boardB.intellect;
        board.gold += boardB.gold;

        return board;



    }
    /// <summary>
    /// 未完成待续 更新随着属性的增长二增加
    /// </summary>
    /// <param name="a">The first <see cref="BoradProperty"/> to add.</param>
    /// <param name="b">The second <see cref="BoradProperty"/> to add.</param>
    /// <returns>The <see cref="T:BoradProperty"/> that is the sum of the values of <c>a</c> and <c>b</c>.</returns>
    public static BoradProperty operator +(BoradProperty a, BoradProperty b){
        
        a.AttackValue += b.AttackValue; //1
        a.DefendValue += b.DefendValue;//2
        a.MaxHP += b.MaxHP;//3
        a.MaxMP += b.MaxMP;
        a.HitCombo += b.HitCombo;
        a.CritDamage += b.CritDamage;
        a.ElementEnhance += b.ElementEnhance;

        a.PoisonDamage += b.PoisonDamage;
        a.PoisonRate += b.PoisonRate;


        a.FireDamage += b.FireDamage;
        a.FireRate += b.FireRate;

        a.IceRate += b.IceRate;
        a.IceDamage += b.IceDamage;

        a.StoneDamage += b.StoneDamage;
        a.StoneRate += b.StoneRate;

        a.EletricRate += b.EletricRate;
        a.EletricDur += b.EletricDur;
        a.EletricDamage += b.EletricDamage;
        a.EletricExtraDamage += b.EletricExtraDamage;

        a.BleedRate += b.BleedRate;
        a.BleedDamage += b.BleedDamage;
        a.BleedDur += b.BleedDur;

        a.strength += b.strength;
        a.magic += b.magic;
        a.luck += b.luck;
        a.intellect += b.intellect;
        a.gold += b.gold;

        a.CalcBoardProperty();
        return a;
    }
   
    /// <summary>
    /// 最终计算出来的物理伤害
    /// </summary>
    public float FinalDamage;

    public float AttackValue; //攻击力
    public float DefendValue; //防御力

    public int MaxHP; //最大血量
    

   

    public int MaxMP;  //最大魔法值
  

    public float ElementEnhance; //元素增幅
    public int HitCombo;  //多重链接;
    public float CritDamage; //爆伤


    //冰
    public float IceDamage; //冰冻伤害 
    public float IceRate; //冰冻几率
    //火
    public float FireDamage; //火焰伤害
    public float FireRate;  //灼烧几率
    //电
    public float EletricDamage;  //雷电伤害
    public float EletricRate;  //感电几率
    public float EletricExtraDamage;  //感电伤害
    public float EletricDur; //持续回合
    //毒
    public float PoisonDamage;  //中毒伤害
    public float PoisonRate;    //中毒几率
    //血
    public float BleedDamage;  //出血伤害
    public float BleedRate;    //出血几率
    public int BleedDur;
    //石化
    public float StoneDamage;  //石化伤害
    public float StoneRate;   //石化几率
   
   
    public int strength;
    public int intellect;
    public int luck;
    public int magic;
    public int gold; 
}
public  class BaseThing  {
    public BaseThing(){
       
        damagePopupWhite = Resources.Load("damagePopupWhite") as GameObject;
        damagePopupYellow = Resources.Load("damagePopupYellow") as GameObject;

       
    }





    public GameObject damagePopupWhite;
    public GameObject damagePopupYellow;


    public GameObject entity;
    public Vector2 FixedPositionV2;
    public Vector3 FixedPositionV3;
    public int id;
    public BoradProperty FinalPropertyBoard = new BoradProperty();
    public BoradProperty LevelPropertyBoard = new BoradProperty();

    public bool isAlive = true;
    public string ThingName;
    public int Level;
    public int Grede;
    public string Description;
    public BaseAbility UsedAbilityThisRound;
    public BaseThingInfomation info;
    public int exp;

    public int hp;
    public int mp;

}
