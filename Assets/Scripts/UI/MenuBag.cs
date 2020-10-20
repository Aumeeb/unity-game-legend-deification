using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Analytics;
using System.Security.Cryptography;
public class MenuBag : MonoBehaviour {
    Color32 orange = new Color32(149,96,5,255);
   
    public Transform root;
    public Transform itemNameListRoot;
    public Text prefabsItemText;
    public string[] Items = { "General", "Equip", "Chinese Herb", "Magic", "Quest" };
    public List<Text> preverse = new List<Text>();
    private int selectedIndex=0;
    bool firstOne = true;
    void DestroyChildren(Transform transform)
    {

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }


    }
    public void updateColor(int i){
        preverse.ForEach((t) =>
        {

            t.color = Color.white;
        });
        preverse[i].color = orange;
        loadBag(i);
    }
    



    public void loadBag(int id=0){

        DestroyChildren(root);

        var slot = Resources.Load("itemSlot") as GameObject;
        var find = new List<GameObject>();
        if(id==0){
            find = Inventory.Bag;
        }
        if(id==1){
            find = Inventory.Bag.Where(
                item => item.GetComponent<BaseItem>().belongTo == ItemBelongTo.Equipment)
                            .ToList();
        }
        if (id == 2)
        {
            find = Inventory.Bag.Where(
                item => item.GetComponent<BaseItem>().itemTypes == ItemTypes.Potion)
                           .ToList();
        }
        if (id == 3)
        {
            find = Inventory.Bag.Where(
                item => item.GetComponent<BaseItem>().itemTypes == ItemTypes.MagicGoods ||
                item.GetComponent<BaseItem>().itemTypes == ItemTypes.Horse)
                            .ToList();
        }
        if (id == 4)
        {
            find = Inventory.Bag.Where(
               item => item.GetComponent<BaseItem>().itemTypes == ItemTypes.Quest)
                        .ToList();
        }

        find.ForEach(item =>
        {
            var newOne = Instantiate(slot, Vector3.zero, Quaternion.identity);

            var baseitem = item.GetComponent<BaseItem>();

            newOne.name = baseitem.uniqueId.ToString();
            newOne.gameObject.GetComponent<Image>().sprite = baseitem.icon;
            newOne.gameObject.GetComponent<Image>().enabled = true;

            Text name = newOne.transform.GetChild(0).GetComponent<Text>();
            name.text = "x" + baseitem.amount;

            newOne.transform.SetParent(root);

        });
    }


}
