using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int MaxHealth = 100;
    public int Health = 100;
    public int Damage = 20;
    protected Vector2 Position;
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

    public void UsePotion(Potion potion)
    {
        Heal(potion.Health);
    }

    private void Heal(int potionHealth)
    {
        Health = (Health + potionHealth <= MaxHealth) ? Health + potionHealth : MaxHealth;
    }

    private void BuffDamage(int potionDamage)
    {
        Damage += potionDamage;
    }

    public Vector2 GetPosition()
    {
        return Position;
    }
}
