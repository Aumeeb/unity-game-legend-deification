using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterRarely
{
    common,
    rare,
    veryRare,
    extramelyRare,

}

public class BaseMonster : BaseThing{

    public MonsterRarely monsterRarely;


    public List<BaseAbility> MonsterAbilities = new List<BaseAbility>();


     

}
