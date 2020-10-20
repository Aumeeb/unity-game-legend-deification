using UnityEngine;

public class PoisonAbility : BaseAbility {

    public PoisonAbility() {
        id = 20002;
        abilityName = "毒蛊之粉";
        abilityDescription = "由剧毒生物的毒液研制而成.";
        powerRate = 2;
        touchingDuration = 0f;
        FlyingDuration = 3f;
        mutilTargetTimeSpan = 0.1f;
        targetExtra = 6;
        cost = 20;
        type = AbilityType.Spell;
        PanelType = PanelType.Middle;
        entity = (GameObject)Resources.Load(abilityName);
        skillType = SkillType.Offensive;
        immediately = false; 
    }
}