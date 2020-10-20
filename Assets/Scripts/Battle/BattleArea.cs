using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public enum BattleField{
    Grass,
    Desert,
    Water,
    UnderWater
}
public class BattleArea : MonoBehaviour {
    public int MinMonster = 1;
    public int MaxMonster = 4;
    public BattleField battleField;
    public List<GameObject> Monsters = new List<GameObject>();
    public float[] randomTime = { 1, 2, 3, 4, 5, 6 };
    float timer = 0;
    /// <summary>
    /// The trigger which means after how much time you will encounter a wave of monster
    /// </summary>
    float trigger = 0;
    bool isEnter = false;
    bool isWait = true;
    private bool isPorting = false;
    private BattleStateStart battleStateStart;

    // Use this for initialization
    void Start () {
       var index= Random.Range(0, randomTime.Length);
        trigger = randomTime[index];

        battleStateStart = GetComponent<BattleStateStart>();
	}
	

	// Update is called once per frame
	void Update () {
        //不是战斗模式才开启
        if (!GM.isBattleMode && isEnter && isWait)
        {
            if (Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.A) ||
                Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D)){

                if(timer>trigger){
                    isPorting = true;
                    isWait = false;
                    UserSceneManager.previousScene.TrapPosition = GM.Heroes.First().entity.transform.position;
                    UserSceneManager.previousScene.ScenePath = SceneManager.GetActiveScene().name;
                   
//                    Debug.Log("当前 trriger " + trigger + " 当前timer " + timer);
                }else
                {
                    timer += Time.deltaTime; 
    //                Debug.Log("当前 trriger " + trigger + " 当前timer " + timer);
                }

              
            }
          
             
        }

	}



    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name=="貂蝉"){
            isEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "貂蝉")
        {
            isEnter = false;
        }
    }
    void OnGUI()
    {
        if (isPorting)
        {
            Initiate.Fade("Scenes/Battle", Color.black, 3f, loaded);
        }
    }

    void loaded()
    {
        Debug.Log("trigger a battle!");

        BattleSystem.MinEnemyCount = MinMonster;
        BattleSystem.MaxEnemyCount = MaxMonster+1;  // 不包含最大值 所以要给她增加1
        BattleSystem.Monsters = Monsters;


        // save the previous scene and hero position to UserSceneManager Class


        GM.isBattleMode = true;
        battleStateStart.prepareBattle();
        timer = 0;
        var index = Random.Range(0, randomTime.Length);
        trigger = randomTime[index];


        //after this we will enter battle field scene.. haha
        isPorting = false;
        isWait = true;
    }


}
