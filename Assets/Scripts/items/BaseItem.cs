using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.TriangleNet.Voronoi.Legacy;

public class BaseItem :MonoBehaviour {

    public int amount = 1; //数量
    public float value = 0; //价格
    public string itemCnName;
    public string itemEnName;
    public string itemCnDescription;
    public string itemEnDescription;
    public int uniqueId;
    public ItemTypes itemTypes;
    public ItemGrade ItemGrade = ItemGrade.normal;
    public ItemBelongTo belongTo;
    public BoradProperty boradProperty;
    public Sprite icon;
    public Skills[] Skills;
    public List<BaseAbility> baseAbilities = new List<BaseAbility>();



    public bool canUse=true;

}

public enum ItemTypes
{
    General = 0,
    Weapon = 10000, //武器
    Head = 20000,//头
    Shield = 30000,//盾
    Cloth = 40000, //衣服
    Horse = 50000,  // 坐骑
    Accessories = 60000, //首饰
    MagicGoods = 70000, //魔法物品
    Quest = 80000, //任务
    Potion = 90000,  //药水

}
public enum ItemBelongTo{
    Equipment,
    None,

}
public enum ItemGrade{
    normal,
    great,
    gold,
    purple,
    epic,
}