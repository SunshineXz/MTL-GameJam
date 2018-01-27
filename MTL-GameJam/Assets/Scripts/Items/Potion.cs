using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item {
    public int Health = 50;
	// Use this for initialization
	void Start () {
        Usable = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WorldManager.instance.Character.UsePotion(this);
        }
    }
}
