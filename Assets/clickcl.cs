using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class clickcl : MonoBehaviour {
    public string sceneName = "Scenes/Battle";
	// Use this for initialization
	void Start () {
       var button= GetComponent<Button>();
        button.onClick.AddListener(onClick);
//        Debug.Log("add a Listener");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onClick(){
       
        SceneManager.LoadScene(sceneName);
        GameObject.Find("Aeima").transform.position = Vector3.zero;
        gameObject.SetActive(false);
       

    }
}
