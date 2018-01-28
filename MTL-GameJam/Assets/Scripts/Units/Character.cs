using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Placeable {

    public int MaxHealth = 100;
    public int Health = 100;
    public int Damage = 20;
    protected Tile TileDestination;
 
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
