using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEleAbility : BaseAbility
{

 /// <summary>
 /// 10010
 /// </summary>
    public AttackEleAbility()
    {
        id = 10010;
        abilityName = "Attack";
        powerRate = 1.0f;
        cost = 0;
        touchingDuration = 0.2f;
        hitTimes = 1;
        targetExtra = 0;
        type = AbilityType.Attack;
        PanelType = PanelType.Left;
        entity = (GameObject)Resources.Load("eletricHit");

    }
}
