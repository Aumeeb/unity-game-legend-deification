using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class Utils {

    // Use this for initialization
    public static StoryList Book = loadBook();


    private static StoryList loadBook()
    {
        string path = Application.streamingAssetsPath + "/story.json";
        string jsonStr = File.ReadAllText(path);

         
        var book = JsonUtility.FromJson<StoryList>(jsonStr);

        return book;
    }
     
    public static T load<T>(string filename){
        string path = Application.streamingAssetsPath + "/" + filename;
        string jsonStr = File.ReadAllText(path);

        
        var book = JsonUtility.FromJson<T>(jsonStr);

        return book;
    }

    public static void DestroyChildren(Transform transform)
    {

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }


    }
    public static string NumberToChinese(int n, string suffix){
        string nstr = n.ToString();
        string chinese = "";
        foreach (var item in nstr)
        {
            if (item == '0') chinese += "零";  
            if (item == '1') chinese += "壹";  
            if (item == '2') chinese += "貮";  
            if (item == '3') chinese += "叁";  
            if (item == '4') chinese += "肆";  
            if (item == '5') chinese += "伍";  
            if (item == '6') chinese += "陆";  
            if (item == '7') chinese += "柒";  
            if (item == '8') chinese += "捌";  
            if (item == '9') chinese += "玖";  
                
        }
        return chinese + suffix;

    }
    


    public static Sprite loadSprite(ItemTypes itemTypes , string name){
        string path = "";
            
        switch (itemTypes)
        {
            case ItemTypes.Weapon:
                path = "Equipment/Weapon/" + name;
                break;
            case ItemTypes.Cloth :
                path = "Equipment/Colth/" + name;
                break;
            case ItemTypes.Accessories:
                path = "Equipment/Accessories/" + name;
                break;
            case ItemTypes.MagicGoods:
                path = "Equipment/MagicGoods/" + name;
                break;
            case ItemTypes.Head:
                path = "Equipment/Head/" + name;
                break;
            case ItemTypes.Shield:
                path = "Equipment/Shield/" + name;
                break;
            case ItemTypes.Horse:
                path = "Equipment/Horse/" + name;
                break;

            case ItemTypes.Potion:
                path = "Equipment/Potion/" + name;
                break;
            default:
                break;
        }
         var g=  Resources.Load(path) as GameObject;
        return g.GetComponent<SpriteRenderer>().sprite;
    }




}

