using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum HeroOrder{
    Aeima,
    Jane,
    Npc
}

public class Conversation{
    public string Content;
    public HeroOrder order;
}

public class Chat : MonoBehaviour {



    [SerializeField]
    private RectTransform dialog;

    public Sprite NpcIcon;
    public int StoryNumber = 0;
    private bool IsChatting = false;
    private int chatProcessStep = 0;
    private int storyCount = 0;
    private int currentStoryIndex = 0;
    private Story currentStory = null;
	
	void Start () {

        storyCount = Utils.Book.stories.Count; //get specific story count
        currentStory = getTopic();

	}
	

    //select specific a topic from mutilple topics randamly from JSON file
    private Story getTopic(){

       if (storyCount>0)
        {
            currentStoryIndex = Random.Range(0, storyCount);

            //return Utils.Book.stories[currentStoryIndex];
            return Utils.Book.stories[StoryNumber];
        }else
        {
            return null;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.name == "貂蝉" && Input.GetKeyDown(KeyCode.Space))
        {

          //  Debug.Log("1");
           
            var diaochan = collision.gameObject.GetComponent<Player>();
            
            var roleIcon = dialog.Find("roleIcon").GetComponent<Image>();
            var roleName = dialog.Find("roleName").GetComponent<Text>();
            var content = dialog.Find("content").GetComponent<Text>();
            if (dialog != null && currentStory !=null)
            {

               // Debug.Log(2);

                if(currentStory.sentences.Count>0 && chatProcessStep < currentStory.sentences.Count){

                  //  Debug.Log(3);

                    var sentence = currentStory.sentences[chatProcessStep];
                    dialog.gameObject.SetActive(true);



                    roleIcon.sprite = NpcIcon;
                    roleName.text = sentence.name;

                    
                    if(sentence.name == diaochan.NickName ){
                        roleIcon.sprite = diaochan.heroIcon;
                        roleName.text = diaochan.NickName;
                         
                    }
                    roleName.text = "〖" + roleName.text + "〗";
                    content.text = sentence.content;


                    chatProcessStep++;
                    diaochan.StopVelocity();
                    diaochan.moveable = false;
                    diaochan.isChatting = true;
                    

                }else{
                    currentStory = getTopic();
                    dialog.gameObject.SetActive(false);
              
                    diaochan.isChatting = false;
                    chatProcessStep = 0;

                   
                    diaochan.moveable = true;



                }
  
            }
        }
    }



}
