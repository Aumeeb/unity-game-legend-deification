using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {
    
    public float dis = 0.1f;
    public float amount = 1;
    private bool open;
    public float Dur = 0f; 
    public float C = 0f;
    public Vector3 prePosition;
    private Color color;
    int tick = 0;
    public bool isBattle = false;
    public bool isShining = false;
        
    void Start()
    {
        C = Dur;
        prePosition = transform.position;
        color = gameObject.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if (isBattle)
        {
            if (C < Dur)
            {
                Vector3 v3;
                if (tick % 2 == 0)
                {
                    v3 = new Vector3(prePosition.x + dis, prePosition.y, prePosition.z);
                }
                else
                {
                    v3 = new Vector3(prePosition.x - dis, prePosition.y, prePosition.z);
                }
                tick++;
                //var v3 = transform.position;
                //v3.x = Mathf.Sin(Time.time * speed) * amount;
                transform.position = v3;

                C += Time.deltaTime;
            }
            else
            {
                transform.position = prePosition;

            }

            //shineing

            if (isShining)
            {
                int fastTimes = 10;

                c += Time.deltaTime * fastTimes;

                if (c % 2 > 1.0f)

                {

                    gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);

                }

                else
                {

                    gameObject.GetComponent<Renderer>().material.color = color;

                }


                if(c >= fastTimes* shineDuration){
                    isShining = false;
                    c = 0;
                    gameObject.GetComponent<Renderer>().material.color = color;
                }
            }


        }


    }
       
      


    public void Shocking(float dur=0.2f)
    {
        C = 0;
        Dur = dur;
        isBattle = true;
    }



 
     
 
    public float shineDuration = 1;
    private float c = 0;

    public void Shining(float dur = 1f){
        shineDuration = dur;
        isShining = true;
    }
}
