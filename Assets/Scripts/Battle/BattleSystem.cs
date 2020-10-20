using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour {
    public static int MinEnemyCount = 2;
    public static int MaxEnemyCount = 5;
    public static int EnemyColunm = 12;
    [Header("怪物信息")]
    public Transform enemyContainer;
    public Image icon;
    public Text MonsterName;
    public Text hp;
    public Text mp;
    public static List<GameObject> Monsters = new List<GameObject>();
    public static Dictionary<int, BaseAbility> abilitys = new Dictionary<int, BaseAbility>(); // give monster some ability to do something.

    private static Transform senemyContainer;
    private static Image sicon;
    private static Text sMonsterName;
    private static Text shp;
    private static Text smp;

private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        initAbility();
        senemyContainer = enemyContainer;
        sicon = icon;
        sMonsterName = MonsterName;
        shp = hp;
        smp = mp;
    }
    // Use this for initialization
    void Start () {
        

	}
	
	// Update is called once per frame
	void Update () {
        ChangeShape();
	}
    public static IEnumerator ComeToTrap(float delay)
    {
        
        GM.isBattleMode = false;
        yield return new WaitForSeconds(delay);
        CombatStateMachine.state = BattleStateType.end;
        RewardPopup.hide();

        Initiate.Fade(UserSceneManager.previousScene.ScenePath, Color.black, 3f, backToPreviousScene);
        
    }


    public static void backToPreviousScene(){
        GM.Heroes.ForEach(prop =>
        {
            prop.entity.GetComponent<Player>().moveable = true;

        });
        GM.Heroes[0].entity.transform.position = UserSceneManager.previousScene.TrapPosition;
    }

    void  onload(){
        Debug.Log("oload");
    }
    void initAbility()
    {
        if (abilitys.Count > 0)
            return;
        
        abilitys.Add(10000, new AttackAbility());
        abilitys.Add(10010, new AttackEleAbility());
        abilitys.Add(20000, new FireBallAbility());
        abilitys.Add(20001, new FreezeAbility());

    }
    public static void ShowMonsterInfo(EnemyInfo emenyInfo){
        senemyContainer.gameObject.SetActive(true);
        sicon.sprite = emenyInfo.icon;
        sMonsterName.text = emenyInfo.NameLevel;
        shp.text = emenyInfo.hp;
        smp.text = emenyInfo.mp;
    }
    public static  void HideMonsterInfo(){
        senemyContainer.gameObject.SetActive(false);
    }
    void ChangeShape()
    {
        if (GM.Heroes.Count <= 0)
        {
            Debug.Log("GM heroes count <=  0");
            return;
                
        }
        if (SceneManager.GetActiveScene().name == "World")
        {
           
            GM.Heroes[0].entity.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            GM.Heroes[0].entity.GetComponent<Player>().speed = 80;
        }
        else
        {
            GM.Heroes[0].entity.transform.localScale = new Vector3(1, 1, 1);
            GM.Heroes[0].entity.GetComponent<Player>().speed = 250;

        }
    }
}
