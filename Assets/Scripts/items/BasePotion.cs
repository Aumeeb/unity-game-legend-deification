using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionType
{
    energy,
    hp,
    mp,
}
public class BasePotion : BaseStateItem {


    public PotionType potionType;
	
}
