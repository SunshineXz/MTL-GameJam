using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Tile {

    public Portal LinkedPortal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Item SwitchItem(Item aItem)
    {
        Item temp = TileItem;

        // Drop Item
        aItem.Position = Position;
        TileItem = aItem;
        TileItem.gameObject.GetComponent<Renderer>().enabled = true;

        Item copy = GameObject.Instantiate(aItem.gameObject).GetComponent<Item>();
        copy.transform.parent = WorldManager.instance.GetOtherWorld().gameObject.transform;
        copy.Position = LinkedPortal.Position;
        LinkedPortal.TileItem = copy;
        LinkedPortal.TileItem.gameObject.SetActive(false);

        return temp;
    }
}
