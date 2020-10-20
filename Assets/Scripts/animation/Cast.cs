
using UnityEngine;
using System;



public class Cast : MonoBehaviour  {

    public Vector3 hitTarget ;
    public float Speed = 0.3f;
   
    public AudioClip flying;
    public AudioClip touched;
    public GameObject spellObject;
     AudioSource audioSource;
  

    void Update()
    {
        
            Vector2 vector2 = hitTarget - transform.position;
            transform.Translate(vector2.normalized * Speed);
    }
    public GameObject Create(Vector3 target, Vector3 position)
    {
        spellObject = Instantiate(gameObject, position, Quaternion.identity) as GameObject;
        hitTarget = target;
    
        Play();
        
        return spellObject;
    }

    public void Play()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = flying;
        audioSource.volume = 1;
        audioSource.Play();
    }
}
