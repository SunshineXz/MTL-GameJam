using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
    public int Damage = 20;
    
	// Use this for initialization
	void Start () {
        Usable = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //WorldManager.instance.Character.AddItem(this);
        }
    }
}
