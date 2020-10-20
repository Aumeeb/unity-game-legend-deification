using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect {
    
    /// <summary>
    /// 技能等级
    /// </summary>
    public int level;
    /// <summary>
    /// 状态名称
    /// </summary>
    public string Name;
    /// <summary>
    /// 描述
    /// </summary>
    public string Description;
    /// <summary>
    /// 编号
    /// </summary>
    public int abilityId;
    /// <summary>
    /// 持续的回合
    /// </summary>
    public int durationRound = 1;
    /// <summary>
    /// 伤害
    /// </summary>
    public int damage;
    /// <summary>
    /// 几率成功
    /// </summary>
    public float chance;


	 
}
