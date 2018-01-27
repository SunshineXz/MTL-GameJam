using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Image ItemPicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Item item = WorldManager.instance.GetCurrentCharacter().GetPickedItem(); 
        if (item)
        {
            SpriteRenderer spriterenderer = item.gameObject.GetComponent<SpriteRenderer>();
            ItemPicked = GetComponent<Image>();
            ItemPicked.sprite = spriterenderer.sprite;
        }
    }
}
