using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

    public List<Sprite> BodyPart = new List<Sprite>();
    public List<Sprite> Rewards = new List<Sprite>();
    //public GameObject target = null;
    public float Scale = 1;
    public float GravityScale = 1f;
    public float DestroyTime = 60*10;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void You(float delay=0){

        Invoke("CreateBodyPart", delay);
            
    }

    public void CreateBodyPart(){
        gameObject.SetActive(false);
        BodyPart.ForEach((Sprite obj) => {

            GameObject game = new GameObject();

            SpriteRenderer s = game.AddComponent<SpriteRenderer>();
            Rigidbody2D rg2 = game.AddComponent<Rigidbody2D>();
            CircleCollider2D collider2D = game.AddComponent<CircleCollider2D>();

            rg2.mass = 1f;
            rg2.gravityScale = Random.Range(GravityScale,3);

            s.sprite = obj;
            s.sortingOrder = 100;


            rg2.velocity = new Vector2(Random.Range(1, 6), Random.Range(1, 5));



            // game.transform.parent = gameObject.transform;
            // game.transform.localPosition = new Vector3(0, 0, 0);
            game.transform.localPosition = gameObject.transform.position;
            game.transform.localScale = new Vector3(1 * Scale, 1 * Scale, 1);
            game.transform.localRotation = new Quaternion(0, 0, Random.Range(0, 360), 0);

            Destroy(game, DestroyTime);

        });
    }


}
