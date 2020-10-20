using UnityEngine;
using System.Collections;

public class RunAbility : BaseAbility
{
    public RunAbility()
    {
        id = 10002;
        abilityName = "Run";
        abilityDescription = "get away";
        powerRate = 10f;
        cost = 0;
        type = AbilityType.Common;
        PanelType = PanelType.Left;
    } 
}
