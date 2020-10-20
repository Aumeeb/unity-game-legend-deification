using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface BattleBehave
{
    void FaceToDown();
    void FaceToUp();
    void BattleMode();
    void IdleMode();
}

public class Player :Character,BattleBehave {


    Animator animator;
    Rigidbody2D myBody;
    CircleCollider2D circle2d;
    public bool isChatting ;
    public bool isTranforming = false;
    public AttackAttribute AttackAttribute = AttackAttribute.none;
    public JobType jobType = JobType.Mage;
    public string Description;
    public GameObject mouseAwait;
    public Vector3 lastPosition = Vector3.zero;
    BaseHero hero;


    void InitPlayer(){
        
        hero = new BaseHero();
        var info = new BaseThingInfomation();
        info.attribute = AttackAttribute;
        info.characterType = jobType;
        hero.info = info;


        hero.ThingName = NickName;
        hero.Description = Description;
        hero.entity = gameObject;
        hero.exp = 0;
       
        hero.LevelPropertyBoard.strength = 20000;
        hero.LevelPropertyBoard.intellect = 0022;
        hero.LevelPropertyBoard.magic = 18;
        hero.LevelPropertyBoard.luck = 5;
        hero.LevelPropertyBoard.CalcBoardProperty();

        hero.hp = hero.LevelPropertyBoard.MaxHP;
        hero.mp = hero.LevelPropertyBoard.MaxMP;
      
        hero.spellAbilities.Add(new FireBallAbility());
        hero.spellAbilities.Add(new PoisonAbility());
        hero.spellAbilities.Add(new CharmAbility());
        hero.spellAbilities.Add(new FreezeAbility());
        hero.abilities[0] = new AttackEleAbility();
        GM.Heroes.Add(hero);
      

    }
    
 
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        InitPlayer();
        Pointer(false);


	}
    public void makeScreen(){
        var img = GameObject.Find("test").GetComponent<Image>();
     


        var texture2d = ScreenCapture.CaptureScreenshotAsTexture();
        Debug.Log(texture2d.width);
        Debug.Log(texture2d.height);
        var texture = Sprite.Create(
            texture2d,
            new Rect(0, 0, texture2d.width, texture2d.height),
            new Vector2(0.5f, 0.5f)
        );
        img.sprite = texture;
    }

    // Update is called once per frame
    public override void Update()
    {
        

            
          
            if (moveable)
            {
                base.Update();
                myBody.velocity = direction * speed * Time.deltaTime;

                AnimateMovement(direction);

            }

       

    }
    public void StopVelocity()
    {
        myBody.velocity = Vector2.zero;
      //  moveable = false;

    }
    public void SetControl(bool can){
        moveable = can;
    }
    public void BattleMode(){
        StopVelocity();
        SetControl(false);
       
        animator.SetFloat("x", 0);
        animator.SetFloat("y", -1);
        GetComponent<CircleCollider2D>().isTrigger = true;
    }
    public void IdleMode(){
        SetControl(true);
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    public void FaceToDown(){
        animator.SetFloat("x", 0);
        animator.SetFloat("y", -1);
    }
    public void FaceToUp(){
        animator.SetFloat("x", 0);
        animator.SetFloat("y", 1);
    }

    public void AnimateMovement(Vector2 direction){
       
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);

    }
    public void Pointer(bool show){
        mouseAwait.SetActive(show);
    }
}
