using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    string Name;
    static public bool Usable = false; 
    public Vector2 Position;
	// Use this for initialization
	void Start () {
		
	}

    private void OnValidate()
    {
        transform.position = Position * 1.6f;
    }

    // Update is called once per frame
    void Update () {
        
	}
}
