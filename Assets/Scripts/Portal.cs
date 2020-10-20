using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Networking.NetworkSystem;
public enum Locale
{
    
    李靖府邸入口,
    世界地图_李靖府邸出口,
    东海龙宫入口,
    东海龙宫入口返回,
    地狱小径,
    战场,
}
public class PortalInfo
{
    public Vector3 vector3 = Vector3.zero;
    public string ScenePath;
    public TrapField trap;
    public Locale locale;
    public string localName;
    public Vector3 TrapPosition;



    public PortalInfo(Vector3 vector3, string path,TrapField trap)
    {
        this.vector3 = vector3;
        this.ScenePath = path;
        this.trap = trap;
    }
    public PortalInfo(){}
}

public class LocaleManager{


    public static Dictionary<Locale,PortalInfo> GetLocale(){
        var l = new Dictionary<Locale, PortalInfo>();
        l.Add(Locale.世界地图_李靖府邸出口,  new PortalInfo( new Vector3(-9.5f, 7, -1), "World" , TrapField.WorldGround));
        l.Add(Locale.李靖府邸入口, new PortalInfo (new Vector3(24f, -38, -1),"Started" , TrapField.SingleRoom));
        l.Add(Locale.地狱小径, new PortalInfo(new Vector3(118, 110, -1), "Chapter1/HellPath1" , TrapField.SingleRoom));
        l.Add(Locale.东海龙宫入口, new PortalInfo(new Vector3(8, 5, -1), "World", TrapField.WorldUnderSea));
        l.Add(Locale.东海龙宫入口返回, new PortalInfo(new Vector3(6.5f, 5, -1), "World", TrapField.WorldGround));
      
        return l;
    }



}
public class Portal : MonoBehaviour {



    public Locale locale;
    private string sceneName = "Scenes/";
    public Vector3 position = new Vector3( -2.45f, 0.42f, -1);
    private bool isPorting = false;
    private Player player;


       

    private void Start()
    {
        
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if(collision.name=="貂蝉"){
            player = collision.gameObject.GetComponent<Player>();
            if(player.isTranforming){
                return;

                //if char is transformming . we dont wanto recall this function.anyway.
            }
            player.isTranforming = true;
            
            position = LocaleManager.GetLocale()[locale].vector3;

           


      
           
            sceneName += LocaleManager.GetLocale()[locale].ScenePath;

             isPorting = true;
          
            
          
        }
       
    }
     

    void OnGUI()
    {
        if (isPorting)
        {
            
            Initiate.Fade(sceneName, Color.black, 3f, onload);
        }
    }

    void onload()
    {
        Debug.Log("onload 触发");
        UserSceneManager.previousScene = UserSceneManager.current;
        UserSceneManager.current = LocaleManager.GetLocale()[locale];
        player.replace(position);
        player.isTranforming = false;
        if(UserSceneManager.current.trap == TrapField.WorldUnderSea){
            WorldMap.ShowSea();
        }
        if (UserSceneManager.current.trap == TrapField.WorldGround)
        {
            WorldMap.ShowGround();
        }
         
     
        isPorting = false;
    }

}
