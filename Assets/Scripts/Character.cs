using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Character : MonoBehaviour {


    public string NickName;
    [SerializeField]
    public Sprite heroIcon;
    public bool moveable = true;
    public float speed = 200;
    public Vector2 direction;
    public Direction FaceTo;
    public List<GameObject> soilder;
    static Character instance;
	// Use this for initialization
	void Start () {     
        DontDestroyOnLoad(gameObject);
	}

    public virtual void Update()
    {
        move();
    }

   
    void move () {
        
            GetInput();

           // transform.Translate(direction * speed * Time.deltaTime);
            GetFaceTo();

	}

    internal void replace(object position)
    {
        throw new NotImplementedException();
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
        }

    }



    public void replace(Vector3 vector3){
        transform.localPosition = vector3;
    }
    public bool isFaceToFace(Vector3 yourVector3){
        //  transform.localPosition
        return false;
    }
    public Direction GetFaceTo(){
        if (direction.x == -1f){
            FaceTo = Direction.Left;
        }else if(direction.x ==1){
            FaceTo= Direction.Right;
        }else if(direction.y ==1){
            FaceTo = Direction.Up;
        }else if(direction.y ==-1){
            FaceTo = Direction.Down;
        }
        return FaceTo;
    }
}
