using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using System;

public class Inventory : MonoBehaviour  {
    public Transform BagContainer;

    public GameObject tooltip;
    public Text text;
    public Text visualText;
    //装备系统
    private int selectedItemId;
    public static List<GameObject> ItemStore = new List<GameObject>();
    public static List<PlayerEquiped> equipmentItem = new List<PlayerEquiped>();
    public static List<GameObject> Bag = new List<GameObject>();
	// Use this for initialization
	void Start () {
        Debug.Log("Inventory Start");

        loadEquipment();
        loadBag();
	}


    void Awake()
    {
        Debug.Log("Inventory Awake");
        initEquipment();
    }

    void initEquipment()
    {
        var all= Resources.LoadAll<GameObject>("Equipment");
      
        ItemStore.AddRange(all);

    }
    void loadBag()
    {
        Bag.AddRange(ItemStore);
    }

    void loadEquipment()
    {
        for (int i = 0; i < GM.Heroes.Count; i++)
        {
            equipmentItem.Add(new PlayerEquiped());



            var cloths = ItemStore[0].GetComponent<BaseItem>();
            equipmentItem[i].cloth = cloths;
            

            var asharpweapon = ItemStore.First(p=>p.GetComponent<BaseItem>().itemTypes == ItemTypes.Weapon).GetComponent<BaseItem>();
            equipmentItem[i].Weapon = asharpweapon;
             
        }
    }

    public void ShowPopup(GameObject go){
        Debug.Log(go.name);
        var modifyMousePosition = Input.mousePosition;
        modifyMousePosition.y -= 100;
        tooltip.transform.position = modifyMousePosition;
        tooltip.SetActive(true);
        

       var baseItem=  ItemStore.Find(prop => prop.GetComponent<BaseItem>().uniqueId.ToString() == go.name).GetComponent<BaseItem>();
       var itemText=  loadItemInfo(baseItem);
        text.text = itemText;
        visualText.text = itemText;
             
    }

    public void ShowBagPopup(GameObject go){
        
        ShowPopup(go);
    }

    public void HidePopUp(){
        tooltip.SetActive(false);
    }


    public string loadItemInfo(BaseItem baseItem){
        string str = "";

        switch (baseItem.ItemGrade)
        {
            case ItemGrade.epic:
                str += "<color=orange><size=50>"+ baseItem.name +"</size></color>\n\n";
                break;
            case ItemGrade.gold:
                str += "<color=#F6F17C><size=50>" + baseItem.name + "</size></color>\n\n";
                break;
            case ItemGrade.great:
                str += "<color=#0B7904><size=50>" + baseItem.name + "</size></color>\n\n";
                break;
            case ItemGrade.purple:
                str += "<color=#995D9A><size=50>" + baseItem.name + "</size></color>\n\n";
                break;
            case ItemGrade.normal:
                str += "<color=black><size=50>" + baseItem.name + "</size></color>\n\n";
                break;
            default:
                break;
        }
        if (baseItem.boradProperty.AttackValue > 0)
        {
            str += "<size=40>+" +baseItem.boradProperty.AttackValue + " 攻击力 </size>\n";
        }
        if (baseItem.boradProperty.DefendValue > 0)
        {
            str += "<size=40>+" +baseItem.boradProperty.DefendValue + " 防御力</size>\n";
        }
        str += "\n";
        if(baseItem.boradProperty.strength>0){
            str += "<size=40>+" +baseItem.boradProperty.strength + " 力量</size>\n";
        }
        if (baseItem.boradProperty.intellect > 0)
        {
            str += "<size=40>+" +baseItem.boradProperty.intellect + " 智力</size>\n";
        }
        if (baseItem.boradProperty.luck > 0)
        {
            str += "<size=40>+" +baseItem.boradProperty.luck + " 幸运</size>\n";
        }
        if (baseItem.boradProperty.magic > 0)
        {
            str += "<size=40>+" +baseItem.boradProperty.magic + " 魔力</size>\n";
        }
        if (baseItem.boradProperty.MaxHP > 0)
        {
            str += "<size=40><color=#0B517E>+" + baseItem.boradProperty.MaxHP + " 生命值</color></size>\n";
        }

        if (baseItem.boradProperty.MaxMP > 0)
        {
            str += "<size=40><color=#0B517E>+" + baseItem.boradProperty.MaxMP + " 魔法值</color></size>\n";
        }
        //血

        if(baseItem.boradProperty.BleedDamage>0){
            str += "<size=40><color=red>+" + baseItem.boradProperty.BleedDamage + " 出血伤害</color></size>\n";
        }
        if (baseItem.boradProperty.BleedDur > 0)
        {
            str += "<size=40><color=red>+" + baseItem.boradProperty.BleedDur + " 出血持续回合</color></size>\n";
        }
        if (baseItem.boradProperty.BleedRate > 0)
        {
            str += "<size=40><color=red>+" + baseItem.boradProperty.BleedRate + "% 出血几率</color></size>\n";
        }

        //血

        if (baseItem.boradProperty.EletricDamage > 0)
        {
            str += "<size=40><color=#43B8D9>+" + baseItem.boradProperty.EletricDamage + " 电感伤害</color></size>\n";
        }
        if (baseItem.boradProperty.EletricDur > 0)
        {
            str += "<size=40><color=#43B8D9>+" + baseItem.boradProperty.EletricDur + " 电感持续回合</color></size>\n";
        }
        if (baseItem.boradProperty.EletricRate > 0)
        {
            str += "<size=40><color=#43B8D9>+" + baseItem.boradProperty.EletricRate + "% 电感几率</color></size>\n";
        }
        if (baseItem.boradProperty.EletricExtraDamage > 0)
        {
            str += "<size=40><color=#43B8D9>+" + baseItem.boradProperty.EletricExtraDamage + " 电感时附加额外伤害</color></size>\n";
        }
        return str;



    }
}
