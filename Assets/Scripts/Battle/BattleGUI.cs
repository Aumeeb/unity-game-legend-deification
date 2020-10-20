using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum PanelType
{
    /// <summary>
    /// will place in left side of content
    /// </summary>
    Left,
    /// <summary>
    /// will place in middle side of content
    /// </summary>
    Middle,
    /// <summary>
    /// will place in right side of content
    /// </summary>
    Right,
    /// <summary>
    /// will ignore
    /// </summary>
    All,
    Not,

}
public class BattleGUI : MonoBehaviour
{
    
    public RectTransform leftPanel;
    public RectTransform middlePanel;
    public RectTransform content;
    public RectTransform rightPanel;
    public GameObject prefabHeroesSlot;
    public Text cash;

    bool PanelDraw= false;
   

    private CalculateDamage calculateDamage = new CalculateDamage();
    private UIBuilder UI;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        UI = gameObject.GetComponent<UIBuilder>();
        CombatStateMachine.OnEnemyFinished += () => { 
            PanelDraw = false; 
            ClearLM();
            CombatStateMachine.roundRecords = new List<RoundRecord>();
        };

        CalculateDamage.OnHeroesChoised += () =>
        {
            ClearLM();
        };

        CombatStateMachine.OnComeBacking += () =>
        {
            prefabHeroesSlot.SetActive(false);
        };
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(UnityEngine.Random.Range(0, 2));
        if(GM.isBattleMode){
            cash.gameObject.SetActive(false);
            createHeroesSlot();
          //  SetActive();
            string hp = GM.Heroes[0].hp + "/" + GM.Heroes[0].FinalPropertyBoard.MaxHP;
           
            switch (CombatStateMachine.state)
            {
                case BattleStateType.Idle:
                    PanelSwitch(PanelType.All, false);

                    break;
                case BattleStateType.HeroesChoise:
                    createBattlePanel();

                    break;
                case BattleStateType.EnemiesChoise:
                    
                    break;
                default:
                   
                    break;
            }
        }else
        {
            SetActive(false);
            cash.gameObject.SetActive(true);
        }


    }


    void SetActive(bool active=true){
        leftPanel.gameObject.SetActive(active);
        middlePanel.gameObject.SetActive(active);
        rightPanel.gameObject.SetActive(active);
       
  
    }

 

    public void DisplayAbilityList(BaseAbility ability){
        DestroyChildren(content.transform);

       
        if (ability.type == AbilityType.Spell)
        {

            GM.Heroes[CombatStateMachine.whoIsNext].spellAbilities.ForEach((BaseAbility spellAbility) =>
            {
                if (spellAbility.cost > GM.Heroes[CombatStateMachine.whoIsNext].mp)
                {
                    Button button = UI.CreateImageButton(content.transform, spellAbility.abilityName, spellAbility,false);

                   
                }
                else
                {
                    Button button = UI.CreateImageButton(content.transform, spellAbility.abilityName, spellAbility);

                    button.onClick.AddListener(() =>
                    {

                        DrawMiddleList(spellAbility);
                    });
                }

            });
                      
        }
        if (ability.type== AbilityType.Attack)
        {
            
            DrawMiddleList(ability);
        }

    }

    void DrawMiddleList(BaseAbility ability)
    {
        DestroyChildren(content.transform);
        GM.baseMonstersInfo.ForEach((monster =>
        {
        UI.CreateButton(content.transform, monster.ThingName).onClick.AddListener(() =>
        {
            DestroyChildren(content.transform);



                //保存记录当前一轮
            var monsterId = new List<int>();
            monsterId.Add(monster.id);
        CombatStateMachine.roundRecords.Add(
                new RoundRecord(
                    GM.Heroes[CombatStateMachine.whoIsNext],
                    monsterId,
                    ability
                    ));

                if (CombatStateMachine.NextHero())  //whoIsNext 增长的地方 (1)
            {

                ClearLM();
                createBattlePanel();
            }else
            {
                    
                   // PanelSwitch(PanelType.All,false);
                    CombatStateMachine.isHeroesTurn = true;
                    CombatStateMachine.state = BattleStateType.CalculateDamage;
            }
        
        });
       


    }));
    }

     void createBattlePanel()
    {
        if (GM.Heroes.Count>0)
        {
           

            if(!PanelDraw){
                 
                //绘制左侧面板
                GM.Heroes[CombatStateMachine.whoIsNext]
                  .abilities
                  .Where( type => type.PanelType== PanelType.Left)
                  .ToList()
                  .ForEach((BaseAbility ability) =>
                  {
                    
                    Button button = UI.CreateButton(leftPanel.transform, ability.abilityName);
                    button.onClick.AddListener(() => DisplayAbilityList(ability));

                  });
              //  GM.Heroes[CombatStateMachine.whoIsNext].entity.GetComponent<Player>().Pointer(true);
                PanelDraw = true;
                PanelSwitch(PanelType.All);
            }


        }else
        {
            Debug.Log("no hero found to draw");
        }
       
        
    }

    /// <summary>
    /// indicator the panel whether show or hide 
    /// </summary>
    /// <param name="type">Type.</param>
    /// <param name="isShow">If set to <c>true</c> is show.</param>
    public void PanelSwitch(PanelType type,bool isShow=true)
    {
        switch (type)
        {
            case PanelType.All:
                leftPanel.gameObject.SetActive(isShow);
                middlePanel.gameObject.SetActive(isShow);
                rightPanel.gameObject.SetActive(isShow);
                prefabHeroesSlot.gameObject.SetActive(isShow);
                cash.gameObject.SetActive(isShow);
                break;
            case PanelType.Left:
                leftPanel.gameObject.SetActive(isShow);
                break;
            case PanelType.Middle:
                middlePanel.gameObject.SetActive(isShow);
                break;
            case PanelType.Right:
                rightPanel.gameObject.SetActive(isShow);
                break;
        }
    }
   
    void DestroyChildren(Transform transform){

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

       
    }

    public void createHeroesSlot(){
        DestroyChildren(prefabHeroesSlot.transform);
        if(GM.Heroes.Count==2){
            prefabHeroesSlot.GetComponent<HorizontalLayoutGroup>().spacing = -1500;
        }
       
        foreach (var hero in GM.Heroes)
        {
         
            UI.CreateSlot(prefabHeroesSlot.transform,hero);
        }

       
    }
    public void ClearLM(){
        DestroyChildren(leftPanel);
        PanelDraw = false;
        DestroyChildren(content);
    }

}