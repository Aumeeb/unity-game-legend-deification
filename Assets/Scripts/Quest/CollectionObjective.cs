using UnityEngine;
using UnityEditor;

public class CollectionObjective : IQuestObjectve
{
    private string title;
    private string descripton;
    private int collectionAmount; //total amount of whatever we need
    private int currentAmount; // starts at 0
    private GameObject itemToCollect;

    public CollectionObjective(string titleVerb, int totalAmount,GameObject item,string descrip)
    {
        title = titleVerb + " " + totalAmount +" " + item.name;
        descripton = descrip;
        itemToCollect = item;
        currentAmount = 0;
        collectionAmount = totalAmount;
    }

    public string Title
    {
        get
        {
            return title;
        }
    }

    public string Decsription
    {
        get
        {
            return descripton;
        }
    }

    public int CollectionAmount
    {
        get
        {
            return collectionAmount;
        }
    }
    public int CurrentAmount
    {
        get
        {
            return currentAmount;
        }
    }
    public GameObject ItemToCollect { get { return itemToCollect; } }
    public void CheckProgress()
    {
        
    }

    public void UpdateProgress()
    {
       
    }
}