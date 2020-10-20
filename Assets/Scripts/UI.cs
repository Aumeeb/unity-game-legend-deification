using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    static UI instance;
	// Use this for initialization
	void Start () {

        if (instance != null)
        {
            //  GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            instance = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
