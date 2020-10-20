using UnityEngine;
using System.Collections;

public class FireBallAbility : BaseAbility
{
    /// <summary>
 /// 20000
 /// </summary>
    public FireBallAbility(){
        id = 20000;
        abilityName = "火球术";
        abilityDescription = "使用火球燃烧敌人.";
        powerRate = 1.5f;
        cost = 5;
        type = AbilityType.Spell;
        FlyingDuration = 1;
        PanelType = PanelType.Middle;
        targetExtra = 1;
        skillType = SkillType.Offensive;
        entity = (GameObject)Resources.Load(abilityName);
        immediately = false;
    }    
     

  
}
