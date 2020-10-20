using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuSpell : MonoBehaviour {

    //英雄列表
    public RectTransform HeroNameButtonGroupParent;
    public GameObject HeroNameButtonGroup;
    private List<Text> HeroNameArray = new List<Text>();
    //魔法清单
    public RectTransform SpellButtonGroupParent;
    public GameObject SpellButtonGroup;
    //技能描述
    public Text description;


    private Color32 selectColor = new Color32(166, 107, 16,255);
    private Color32 unSelectedColor = Color.white;
   
    public int heroIndex = 0;
    public void loadSpell(){

       
        bool isFirst = true;
        HeroNameArray = new List<Text>();
        Utils.DestroyChildren(HeroNameButtonGroupParent.transform);
        int i = 0;
        GM.Heroes.ForEach((BaseHero obj) =>
        {
           
            GameObject one= GameObject.Instantiate(HeroNameButtonGroup, Vector3.zero, Quaternion.identity) as GameObject;
            one.name = i.ToString();
            i++;

            Button button= one.gameObject.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                heroIndex = int.Parse(one.name);
                RendererMagicList(heroIndex);
                for (int j = 0; j< HeroNameArray.Count; j++)
                {
                    if(heroIndex==j)
                    HeroNameArray[j].color = selectColor;
                    else 
                        HeroNameArray[j].color = Color.white;
                }

            });
            foreach (Transform child in one.transform)
            {
               
                if( child.gameObject.name == "Text"){
                    
                    Text text=  child.GetComponent<Text>();
                    HeroNameArray.Add(text);
                    text.text = obj.ThingName;
                    if(isFirst){
                        text.color = new Color32(166, 107, 16, 255);
                        isFirst = false;
                    }

                   
                }
                if (child.gameObject.name== "Image")
                {
                    Image image = child.GetComponent<Image>();
                    image.sprite = obj.entity.GetComponent<Player>().heroIcon;
                }
            }

            one.transform.SetParent(HeroNameButtonGroupParent);
        });

        RendererMagicList(0);
    }

    public void RendererMagicList(int heroIndex,int listIndex= 0)
    {
        int i = 0;
        bool isFirst = true;
        Utils.DestroyChildren(SpellButtonGroupParent.transform);


        GM.Heroes[heroIndex].spellAbilities.ForEach((BaseAbility obj) =>
        {
            GameObject one = GameObject.Instantiate(SpellButtonGroup, Vector3.zero, Quaternion.identity) as GameObject;
            one.name = i.ToString();
           
            Button button = one.GetComponent<Button>();


            button.onClick.AddListener(() =>
            {
                Debug.Log(one.name);
                RendererMagicList(heroIndex, int.Parse(one.name));
            });

            if(listIndex == i){
                one.GetComponent<Image>().color = new Color32(244, 244, 244, 45);
                description.text = obj.abilityDescription;

            }else{
                one.GetComponent<Image>().color = new Color32(244, 244, 244, 0);
            }

            foreach (Transform child in one.transform)
            {
                if (child.gameObject.name == "desc")
                {

                    Text text = child.GetComponent<Text>();
                    text.text = obj.abilityName + " " + obj.level + "级";

                }
                if (child.gameObject.name == "cast")
                {

                    Text text = child.GetComponent<Text>();
                    text.text = obj.cost.ToString();

                }
                if (child.gameObject.name == "icon")
                {
                    Image image = child.GetComponent<Image>();
                    image.sprite = obj.GetIcon();
                }


            }
            if (isFirst)
            {
                description.text = obj.abilityDescription;
                isFirst = false;
            }
            i++;
            one.transform.SetParent(SpellButtonGroupParent);
        });
    }
     
}
