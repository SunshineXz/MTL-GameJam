using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character {
    bool Moving = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ReactToUserInput();
        MoveCharacter();
    }

    public void ReactToUserInput() {
        if (Moving)
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
    }

    public void SetNextPosition(Vector2 nextPosition)
    {
        // VÉRIFIER AVEC LE WORLD SI LA TILE EST TRAVERSABLE

        TileDestination = WorldManager.instance.GetTileAtPosition(nextPosition);
        if (TileDestination && TileDestination.CanGoThrough)
        {
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

}
