using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuYou : MonoBehaviour {
    [Header("Icon")]
    public Text Hname;
    public Text level;
    public Image icon;
    public Text desc;
    [Header("4D")]
    public Text Strength;
    public Text intellect;
    public Text luck;
    public Text magic;
    [Header("state")]
    public Text hp;
    public Text mp;
    public Text exp;

    public Text attack;
    public Text defend;
    public Text EleEnhangce;
    public Text crilDamage;
    public Text HitCombo;
    public Text ice;
    public Text fire;
    public Text eletric;
    public Text bleed;
    public Text fossilization;
    public Text potion;

    [Header("select hero")]
    public Button next;
    public Button pre;

    [Header("weapon")]
    public Image weaponImage;
    public Text weaponText;
    [Header("head")]
    public Image headImage;
    public Text headText;
    [Header("horse")]
    public Image horseImage;
    public Text horseText;
    [Header("shield")]
    public Image shieldImage;
    public Text  shieldText;
    [Header("cloth")]
    public Image clothImage;
    public Text clothText;
    [Header("magicgoods")]
    public Image magicgoodsImage;
    public Text magicgoodsText;
    [Header("accessories")]
    public Image AccessoriesImage;
    public Text accessoriesText;

    //当前英雄的索引序号
    private int heroIndex;




	// Use this for initialization
	void Start () {
        next.onClick.AddListener(() => {
            heroIndex++;
            if (heroIndex == GM.Heroes.Count)
                heroIndex = 0;
            
            loadHeroInfo(heroIndex);
        });

        pre.onClick.AddListener(() => {
            heroIndex--;
            if (heroIndex == -1)
                heroIndex = GM.Heroes.Count - 1;
            
            loadHeroInfo(heroIndex);
        });



	}
	

    public void NextHero(){
        
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void loadHeroInfo(int heroIndex=0){

        var equipmentBorad = CalculateDamage.LoadEquipment(Inventory.equipmentItem[heroIndex]);
        var levelBoard = GM.Heroes[heroIndex].LevelPropertyBoard;
        GM.Heroes[heroIndex].FinalPropertyBoard = BoradProperty.CreateNewBoardProperty(equipmentBorad, levelBoard).CalcBoardProperty();

        var player = GM.Heroes[heroIndex];
        Hname.text = player.ThingName;
        level.text = "Lv"+player.Level.ToString();
        icon.sprite = player.entity.GetComponent<Player>().heroIcon;
        desc.text = player.Description;


        Strength.text = player.FinalPropertyBoard.strength.ToString();
        intellect.text = player.FinalPropertyBoard.intellect.ToString();
        luck.text = player.FinalPropertyBoard.luck.ToString();
        magic.text = player.FinalPropertyBoard.magic.ToString();

        hp.text = player.hp + "/" + player.FinalPropertyBoard.MaxHP;
        mp.text = player.mp + "/" + player.FinalPropertyBoard.MaxMP;
        exp.text = player.exp.ToString();




        attack.text = player.FinalPropertyBoard.FinalDamage.ToString();
        defend.text = player.FinalPropertyBoard.DefendValue.ToString();
        EleEnhangce.text = player.FinalPropertyBoard.ElementEnhance.ToString();
        crilDamage.text = player.FinalPropertyBoard.CritDamage.ToString();
        HitCombo.text = player.FinalPropertyBoard.HitCombo.ToString();

        ice.text = player.FinalPropertyBoard.IceDamage.ToString();
        fire.text = player.FinalPropertyBoard.FireDamage.ToString();
        eletric.text = player.FinalPropertyBoard.EletricDamage.ToString();
        bleed.text = player.FinalPropertyBoard.BleedDamage.ToString();
        fossilization.text = player.FinalPropertyBoard.StoneDamage.ToString();
        potion.text = player.FinalPropertyBoard.PoisonDamage.ToString();
      
            

        //weapon
        if(Inventory.equipmentItem[heroIndex].Weapon!=null){
            weaponText.text = Inventory.equipmentItem[heroIndex].Weapon.itemCnName;
            weaponImage.sprite = Inventory.equipmentItem[heroIndex].Weapon.icon;
            weaponImage.name = Inventory.equipmentItem[heroIndex].Weapon.uniqueId.ToString();
            weaponImage.gameObject.SetActive(true);
        }else
        {
            weaponImage.gameObject.SetActive(false);
        }

        //head
        if (Inventory.equipmentItem[heroIndex].head != null)
        {
            headText.text = Inventory.equipmentItem[heroIndex].head.itemCnName;
            headImage.sprite = Inventory.equipmentItem[heroIndex].head.icon;
            headImage.name = Inventory.equipmentItem[heroIndex].head.uniqueId.ToString();
            headImage.gameObject.SetActive(true);
        }else
        {
        headImage.gameObject.SetActive(false);
        }

        //cloth
        if (Inventory.equipmentItem[heroIndex].cloth != null)
        {
            clothText.text = Inventory.equipmentItem[heroIndex].cloth.itemCnName;
            clothImage.sprite =Inventory.equipmentItem[heroIndex].cloth.icon;
            clothImage.name = Inventory.equipmentItem[heroIndex].cloth.uniqueId.ToString();
            clothImage.gameObject.SetActive(true);
        }
        else
        {
            clothImage.gameObject.SetActive(false);
        }
        //horse
        if (Inventory.equipmentItem[heroIndex].horse != null)
        {
            horseText.text = Inventory.equipmentItem[heroIndex].horse.itemCnName;
            horseImage.sprite =Inventory.equipmentItem[heroIndex].horse.icon;
            horseImage.name = Inventory.equipmentItem[heroIndex].horse.uniqueId.ToString();
            horseImage.gameObject.SetActive(true);
        }
        else
        {
            horseImage.gameObject.SetActive(false);
        }
        //shield
        if (Inventory.equipmentItem[heroIndex].shield != null)
        {
            shieldText.text = Inventory.equipmentItem[heroIndex].shield.itemCnName;
            shieldImage.sprite = Inventory.equipmentItem[heroIndex].shield.icon;
            shieldImage.name = Inventory.equipmentItem[heroIndex].shield.uniqueId.ToString();
            shieldImage.gameObject.SetActive(true);
        }
        else
        {
            shieldImage.gameObject.SetActive(false);
        }
        // magicgoods
        if (Inventory.equipmentItem[heroIndex].MagicGoods != null)
        {
            magicgoodsText.text = Inventory.equipmentItem[heroIndex].MagicGoods.itemCnName;
            magicgoodsImage.sprite =  Inventory.equipmentItem[heroIndex].MagicGoods.icon;
            magicgoodsImage.name = Inventory.equipmentItem[heroIndex].MagicGoods.uniqueId.ToString();
            magicgoodsImage.gameObject.SetActive(true);
        }
        else
        {
            magicgoodsImage.gameObject.SetActive(false);
        }
        //Accessories
        if (Inventory.equipmentItem[heroIndex].accessories != null)
        {   AccessoriesImage.name = Inventory.equipmentItem[heroIndex].accessories.uniqueId.ToString();
            accessoriesText.text = Inventory.equipmentItem[heroIndex].accessories.itemCnName;
            AccessoriesImage.sprite = Inventory.equipmentItem[heroIndex].accessories.icon;
            AccessoriesImage.gameObject.SetActive(true);
        }
        else
        {
            AccessoriesImage.gameObject.SetActive(false);
        }
    }


    

}
