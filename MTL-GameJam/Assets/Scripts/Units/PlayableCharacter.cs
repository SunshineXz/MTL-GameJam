using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character {
    Item PickedItem;
    bool Moving = false;
    bool Controlling = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ReactToUserInput();
        MoveCharacter();
    }

    public void ReactToUserInput() {
        if (Moving || !Controlling)
            return;

        if (Input.GetKey(KeyCode.W))
        {
            SetNextPosition(Position + new Vector2(0, 1));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            SetNextPosition(Position + new Vector2(0, -1));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            SetNextPosition(Position + new Vector2(-1, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            SetNextPosition(Position + new Vector2(1, 0));
        }
        else if (Input.GetKey(KeyCode.E))
        {
            DropItem();
        }
    }

    public void SetNextPosition(Vector2 nextPosition)
    {
        // VÉRIFIER AVEC LE WORLD SI LA TILE EST TRAVERSABLE

        TileDestination = WorldManager.instance.GetTileAtPosition(nextPosition);
        if (TileDestination.TileDoor && !TileDestination.TileDoor.isOpen)
        {
            if(PickedItem.GetType() == typeof(Key))
            {
                TileDestination.TileDoor.OpenDoor();
                PickedItem = null;
            }
        }
        if (TileDestination && TileDestination.CharacterCanGoThrough(PickedItem))
        {
            
            if(TileDestination.TileItem)
            {
                PickedItem = TileDestination.TileItem;
                PickedItem.gameObject.GetComponent<Renderer>().enabled = false;
            }

            Position = nextPosition;
            //transform.position = tile.transform.position;
            Moving = true;
        }
    }

    private void MoveCharacter()
    {
        if (!Moving)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, TileDestination.transform.position, 0.1f);
        
        if(Vector3.Distance(transform.position, TileDestination.transform.position) <= 0.1f)
        {
            transform.position = TileDestination.transform.position;
            Moving = false;
        }
    }

    private void DropItem()
    {
        Tile tile = WorldManager.instance.GetTileAtPosition(Position);
        if (PickedItem != null && tile.GetType() == typeof(Portal))
        {
            Portal portal = (Portal)tile;
            Item portalItem = portal.PickItem();
            portal.DropItem(PickedItem);
            PickedItem = portalItem;
        }
    }

    public void SetControlling(bool controlling)
    {
        Controlling = controlling;
    }
}
