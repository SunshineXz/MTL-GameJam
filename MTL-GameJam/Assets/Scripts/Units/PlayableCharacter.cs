using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character {
    public Item PickedItem;
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
        else if (Input.GetKeyDown(KeyCode.E))
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
                TileDestination.TileItem = null;
                PickedItem.gameObject.GetComponent<Renderer>().enabled = false;

                if(TileDestination.GetType() == typeof(Portal))
                {
                    Portal LinkedPortal = ((Portal)TileDestination).LinkedPortal;
                    LinkedPortal.TileItem = null;
                    LinkedPortal.gameObject.GetComponent<Renderer>().enabled = false;

                }
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
        if (PickedItem != null)
        {
            if(tile.GetType() == typeof(Portal))
            {
                PickedItem = ((Portal)tile).SwitchItem(PickedItem);
            } else
            {
                PickedItem.Position = tile.Position;
                tile.TileItem = PickedItem;
                PickedItem.gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    public void SetControlling(bool controlling)
    {
        Controlling = controlling;
    }
}
