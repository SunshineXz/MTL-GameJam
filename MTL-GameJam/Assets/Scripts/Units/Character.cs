using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int Health = 100;
    public float MoveSpeed = 5.0f;
    protected Vector2 Position;
 
    public Character() {
        Position = Vector2.zero;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

 
}
