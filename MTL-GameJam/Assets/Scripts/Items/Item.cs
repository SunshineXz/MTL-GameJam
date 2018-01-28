using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Placeable
{
    string Name;
    static public bool Usable = false; 

	// Use this for initialization
	void Start () {
		
	}

    public virtual void Use(){  }
}
