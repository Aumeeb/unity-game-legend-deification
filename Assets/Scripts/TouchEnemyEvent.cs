using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchEnemyEvent : MonoBehaviour {
    private Player character;
    private bool isPorting;
    private string sceneName = "Scenes/Battle";
    public Vector3 position = new Vector3(-2.45f, 0.42f, -1);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Aeima")
        {
            //character = collision.gameObject.GetComponent<Aeima>();
            //character.BattleMode();

            isPorting = true;
       
        }
    }


    private void OnGUI()
    {
        if (isPorting)
        {
            Initiate.Fade(sceneName, Color.black, 1.2f, func);
        }
    }

    void func()
    {
      //  character.replace(position);
    }
}
