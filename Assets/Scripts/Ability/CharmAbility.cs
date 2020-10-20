using UnityEngine;

public class CharmAbility : BaseAbility{

    public CharmAbility()
    {
        id = 20003;
        abilityName = "狐媚术";
        abilityDescription = "一种妖术,可以魅惑敌人并造成一定伤害.";
        powerRate = 2;
        cost = 10;
        touchingDuration = 0f;
        FlyingDuration = 2.2f;
        mutilTargetTimeSpan = 0.1f;
        targetExtra = 36;
        type = AbilityType.Spell;
        PanelType = PanelType.Middle;
        skillType = SkillType.Offensive;
        entity = (GameObject)Resources.Load(abilityName);
        immediately = false;
    } 
}