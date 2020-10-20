using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSuddenly : MonoBehaviour {
    

    public AudioClip touched;
    AudioSource audioSource;
    public GameObject created;
    public float TouchingTime = 1;
    public float eachone = 0.2f;
    // Use this for initialization
    bool isExsits;




    public void Create(GameObject target, Vector3 position)
    {
        

        created = Instantiate(target, position, Quaternion.identity) as GameObject;
        Destroy(created, TouchingTime);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = touched;
        audioSource.loop = true;
        audioSource.volume = 1;
        Play();
    }
    public void Create(GameObject target, Vector3 position,float hitTimes)
    {


        created = Instantiate(target, position, Quaternion.identity) as GameObject;
        Destroy(created, hitTimes);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = touched;
        audioSource.loop = true;
        audioSource.volume = 1;
        Play();
    }

    public void Play()
    {
        audioSource.Play();
    }

     
}
