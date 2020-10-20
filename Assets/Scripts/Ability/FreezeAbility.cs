
using UnityEngine;

public class FreezeAbility : BaseAbility {
    /// <summary>
 /// 20001
 /// </summary>
    public FreezeAbility()
    {
        id = 20001;
        abilityName = "霜冻冰刺";
        abilityDescription = "在敌人脚下生成寒冷冰霜之刺!";
        powerRate = 1.7f;
        cost = 5;
        targetExtra = 6;
        touchingDuration = 1.6f;
        mutilTargetTimeSpan = 0.2f;
        type = AbilityType.Spell;
        PanelType = PanelType.Middle;
        skillType = SkillType.Offensive;
        immediately = true;
        entity = (GameObject)Resources.Load(abilityName);
    }   
}


