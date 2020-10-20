using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RewardPopup : MonoBehaviour {



    public Transform rewardPanel;
    public static GameObject prefabsItem;
    private GridLayoutGroup glg;
    private static GridLayoutGroup sg;
    private static Transform rp;
    private static List<EachReword> ecr = new List<EachReword>();
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        glg = rewardPanel.GetComponent<GridLayoutGroup>();
        sg = glg;
        rp = rewardPanel;
        prefabsItem = Resources.Load("reward/itemName") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   

    public static IEnumerator Rob(List<EmenyDecription> list,float delay)
    {
        yield return new WaitForSeconds(delay);

        list.ForEach((l) =>  //每一个怪物
        {
            l.list.ForEach((each) =>  //每一个怪物 身上携带的多个宝贝
            {
            int luckly = Random.Range(0, 100);
            if (luckly <= each.dropRate)
            {
                    if (ecr.Exists(p => p.obj.GetComponent<BaseItem>().uniqueId == each.obj.GetComponent<BaseItem>().uniqueId))
                    {
                        var first = ecr.First(p => p.obj.GetComponent<BaseItem>().uniqueId == each.obj.GetComponent<BaseItem>().uniqueId);
                        each.amount += Random.Range(each.minAmount, each.maxAmount);
                        first.amount += each.amount;
                    }

                    else
                    {
                        each.amount += Random.Range(each.minAmount, each.maxAmount);
                        ecr.Add(each);
                    }

                }
               
            });

        });
        Show();
        CombatStateMachine.state = BattleStateType.ComeBack;

    }
    public static void hide(){
        rp.gameObject.SetActive(false);
    }
    public static void Show(){
        
        Utils.DestroyChildren(rp);
        rp.gameObject.SetActive(true);
        int count = ecr.Count;
        float y = sg.cellSize.y;
        float sy = sg.spacing.y;
        float bs = 60;
        float final = bs + y * count + (sy * (count - 1));

        var rect = sg.gameObject.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, final);
          

        for (int i = 0; i < count; i++)
        {
           var one = Instantiate(prefabsItem, Vector3.zero, Quaternion.identity);
           var itemName=  one.GetComponent<Text>();
            var itemImage = one.transform.GetChild(0).GetComponent<Image>();
            var itemNumber = one.transform.GetChild(1).GetComponent<Text>();

            itemName.text = ecr[i].obj.GetComponent<BaseItem>().itemCnName;
            itemImage.sprite = ecr[i].obj.GetComponent<BaseItem>().icon;
            itemNumber.text = "+"+ecr[i].amount.ToString();
            one.transform.SetParent(rp);
        }

        ecr.Clear();
    }


    public static void Hide(){
        rp.gameObject.SetActive(false);
    }
}
