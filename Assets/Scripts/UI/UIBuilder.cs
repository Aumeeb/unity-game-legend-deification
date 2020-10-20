using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuilder : MonoBehaviour {

    public enum ButtonType{
        common,
        image,
    }
    public Button commomButton;
    public Button imageButton;
    public RectTransform heroesSlot;
    void Start()//Creates a button and sets it up
    {
        DontDestroyOnLoad(gameObject);
        //GameObject button = (GameObject)Instantiate(buttonPrefab);
        //button.transform.SetParent(panelToAttachButtonsTo.transform);//Setting button parent
        //button.GetComponent<Button>().onClick.AddListener(OnClick);//Setting what button does when clicked
        //                                                           //Next line assumes button has child with text as first gameobject like button created from GameObject->UI->Button
        //button.transform.GetChild(0).GetComponent<Text>().text = "This is button text";//Changing text
    }
    void OnClick()
    {
        Debug.Log("clicked!");
    }
    /// <summary>
    /// 英雄血槽
    /// </summary>
    /// <returns>The slot.</returns>
    /// <param name="parent">Parent.</param>
    /// <param name="hero">Hero.</param>
    public RectTransform CreateSlot(Transform parent,BaseHero hero){
        RectTransform slot = Object.Instantiate(heroesSlot, Vector2.zero, Quaternion.identity) as RectTransform;

       var theTransform= slot.GetComponent<RectTransform>();
        theTransform.SetParent(parent);
        Text TheName= slot.transform.GetChild(0).GetComponent<Text>();
        Text hp = slot.transform.GetChild(1).GetComponent<Text>();
        Text mp = slot.transform.GetChild(2).GetComponent<Text>();

        TheName.text = hero.ThingName +   " Lv " + hero.Level;
        hp.text = Mathf.Abs(hero.hp).ToString();
        mp.text = Mathf.Abs(hero.mp).ToString();

        return slot;
    }
    public Button CreateButton(Transform parent, string text)//Vector2 cornerTopRight, Vector2 cornerBottomLeft)
    {
        Button button = Object.Instantiate(commomButton, Vector2.zero, Quaternion.identity) as Button;


        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(parent);
        //     rectTransform.anchorMax = cornerTopRight;
        //    rectTransform.anchorMin = cornerBottomLeft;
        //   rectTransform.offsetMax = Vector2.zero;
        //   rectTransform.offsetMin = Vector2.zero;
        var label = button.transform.GetChild(0).GetComponent<Text>();
        label.text = text;
     //   label.fontSize = 24;
     //   label.fontStyle = FontStyle.BoldAndItalic;

        return button;
    }
    public Button CreateImageButton(Transform parent,string text, BaseAbility ability,bool full=true){
        Button button = Object.Instantiate(imageButton, Vector2.zero, Quaternion.identity) as Button;

        Image image= button.GetComponentInChildren<Image>();

        Sprite icon = ability.GetIcon();
         image.sprite = icon;
      //  abilityIcon.sprite = null;
        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(parent);
        //     rectTransform.anchorMax = cornerTopRight;
        //    rectTransform.anchorMin = cornerBottomLeft;
        //   rectTransform.offsetMax = Vector2.zero;
        //   rectTransform.offsetMin = Vector2.zero;
        var label = button.transform.GetChild(0).GetComponent<Text>();
        var mana =  button.transform.GetChild(2).GetComponent<Text>();
       // var label = button.transform.GetChild(0).GetComponent<Text>();
        label.text = text;
        mana.text = ability.cost.ToString();
        //   label.fontSize = 24;
        //   label.fontStyle = FontStyle.BoldAndItalic;
        if (full == false)
        {
            image.color = Color.grey;
            label.color = Color.grey;
            mana.color = Color.grey;
        }
        return button; 
    }


}
