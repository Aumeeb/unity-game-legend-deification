using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackAbility : BaseAbility
{

 /// <summary>
 /// 10000
 /// </summary>
    public AttackAbility()
    {
        id = 10000;
        abilityName = "Attack";
        powerRate = 1.0f;
        cost = 0;
        touchingDuration = 0.2f;
        hitTimes = 1;
        targetExtra = 0;
        type = AbilityType.Attack;
        PanelType = PanelType.Left;
        entity = (GameObject)Resources.Load("hit");

    }
}
