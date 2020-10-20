using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAbility : BaseAbility {
    
    public GuardAbility()
    {
        id = 10001;
        abilityName = "Guard";
        abilityDescription = "Guard";
        powerRate = 0;
        cost = 0;
        PanelType = PanelType.Left;
        type = AbilityType.Common;
        skillType = SkillType.Buff;
    }    
	 
}
