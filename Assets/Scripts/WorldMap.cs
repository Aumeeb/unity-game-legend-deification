using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMap : MonoBehaviour {

    // Use this for initialization
    public GameObject ground;
    public GameObject sea;

    private static GameObject g;
    private static GameObject s;
	void Start () {
        g = ground;
        s = sea;
	}
	
	 

    public static void ShowGround()
    {
        g.SetActive(true);
        s.SetActive(false);
    }
    public static void ShowSea()
    {
        g.SetActive(false);
        s.SetActive(true);
    }
}
