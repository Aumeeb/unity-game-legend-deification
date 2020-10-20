using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class EnemyInfo{
    public Sprite icon;
    public string NameLevel;
    public string hp;
    public string mp;
}
public class EmenyDecription : MonoBehaviour  {

    public List<EachReword> list = new List<EachReword>();
    public BoradProperty State = new BoradProperty();
    public Skills attack;
    public int level;
    public string NickName;

   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    private void FixedUpdate()
    {
         
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        wp.y += 3; //相机
//        Debug.Log(wp);
            var coll = gameObject.GetComponent<Collider2D>();
        if (Input.GetMouseButtonDown(0))
        {
            if (coll.OverlapPoint(wp))
            {
           //     Debug.Log(coll.gameObject.name);

                BaseMonster monster = GM.baseMonstersInfo.Find(prop => prop.ThingName == coll.gameObject.name);

                var einfo = new EnemyInfo();

                einfo.NameLevel = coll.gameObject.name + level;
                einfo.icon = monster.entity.GetComponent<SpriteRenderer>().sprite;
                einfo.hp = monster.hp + "/" + monster.FinalPropertyBoard.MaxHP;
                einfo.mp = monster.mp + "/" + monster.FinalPropertyBoard.MaxMP;
                BattleSystem.ShowMonsterInfo(einfo);
            }
           
        }

    }


}

[Serializable]
public class EachReword{
    public int minAmount;
    public int maxAmount;
    public int amount = 1;
    public float dropRate;
    public GameObject obj;


}
public class FinalRewordInfomation{
    public Sprite image;
   public string ItemName;
   public string count;
}