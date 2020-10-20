using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.U2D.TriangleNet.Voronoi.Legacy;
using System.Text;
using UnityScript.Steps;
using UnityEngine.UI;

public class UIItemManager : MonoBehaviour ,IPointerClickHandler{

    public RectTransform selfRoot;
    public RectTransform menuRoot;

    public RectTransform bag;
    public RectTransform spell;
    public RectTransform you;
  
    public MenuItemsSlot type;
    public bool isOpen = false;

    public static List<bool> vs = new List<bool>(3) { false, false, false };
    public enum MenuItemsSlot
    {
        Bag,
        Spell,
        You
    }

    // Use this for initialization
    void Start () {
        GM.OnStartBattle += () =>
        {
            selfRoot.gameObject.SetActive(false);
            if (GM.isBattleMode)
            {
                for (int i = 0; i < vs.Count; i++)
                {
                    vs[i] = false;
                }
            }
            hide();
            menuRoot.gameObject.SetActive(false);
        };

        GM.OnEndBattle += () =>
        {
            selfRoot.gameObject.SetActive(true);
        };



	}
	
	 
	 

    public void hide()
    {
        bag.gameObject.SetActive(false);
        you.gameObject.SetActive(false);
        spell.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        //set all the vs array to false...


        if(type== MenuItemsSlot.Bag){
            if(vs[0]==false){
                
                MenuItemOpen(0);
            }else
            {
                MenuItemClose();
            }
        }
        if (type == MenuItemsSlot.Spell)
        {
            if (vs[1] == false)
            {
                MenuItemOpen(1);
            }else
            {
                MenuItemClose();
            }
        }
        if (type == MenuItemsSlot.You)
        {
            if (vs[2] == false)
            {
                MenuItemOpen(2);
            }else
            {
                MenuItemClose();
            }
        }
       
    }

    public void MenuItemClose(){
        for (int i = 0; i < vs.Count; i++)
        {
            vs[i] = false;
        }
        bag.gameObject.SetActive(false);
        spell.gameObject.SetActive(false);
        you.gameObject.SetActive(false);
        menuRoot.gameObject.SetActive(false);
    }
    public void MenuItemOpen(int index){
        MenuItemClose();
     
        vs[index] = true;
        switch (type)
        {
            case MenuItemsSlot.Bag:
                bag.gameObject.SetActive(vs[index]);
                if (vs[index])
                {
                    bag.gameObject.GetComponent<MenuBag>().loadBag();
                }
                break;
            case MenuItemsSlot.Spell:
                spell.gameObject.SetActive(vs[index]);
                 
                if (vs[index])
                {
                    spell.gameObject.GetComponent<MenuSpell>().loadSpell();
                }
                break;
            case MenuItemsSlot.You:
                you.GetComponent<MenuYou>().loadHeroInfo();     
                you.gameObject.SetActive(vs[index]);           
                break;
            default:

                break;
        }
       
        menuRoot.gameObject.SetActive(vs[index]);
        
    }

    
}
