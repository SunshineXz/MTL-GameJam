﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Tile {

    public Portal LinkedPortal;
    public Item PortalItem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DropItem(Item aItem)
    {
        PortalItem = aItem;
        LinkedPortal.PortalItem = aItem;
        PortalItem.Position = Position;
        LinkedPortal.PortalItem.Position = LinkedPortal.Position;
        PortalItem.gameObject.GetComponent<Renderer>().enabled = true;
        LinkedPortal.PortalItem.gameObject.GetComponent<Renderer>().enabled = true;
    }

    public Item PickItem()
    {
        Item temp = PortalItem;

        if (temp != null)
        {
            PortalItem.gameObject.SetActive(false);
            LinkedPortal.gameObject.SetActive(false);
        }

        PortalItem = null;
        LinkedPortal.PortalItem = null;
        return temp;
    }
}