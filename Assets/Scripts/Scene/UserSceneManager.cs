using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TrapField
{
    /// <summary>
    /// The world ground.
    /// </summary>
    WorldGround, 
    /// <summary>
    /// The world under sea.
    /// </summary>
    WorldUnderSea,
    /// <summary>
    /// The single room.
    /// </summary>
    SingleRoom,

    BattleGrass
}
public class UserSceneManager : MonoBehaviour {

    public static PortalInfo current = new PortalInfo();
    public static PortalInfo previousScene = new PortalInfo();
    public static Vector3 trapPostionBeforeBattle = Vector3.zero;
    public static TrapField field = TrapField.SingleRoom;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
