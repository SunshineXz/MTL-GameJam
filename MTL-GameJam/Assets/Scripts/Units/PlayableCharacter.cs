using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ReactToUserInput();
	}

    public void ReactToUserInput() {
        if (Input.GetKey(KeyCode.W))
        {
            MoveCharacter(Position + new Vector2(0, 1));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveCharacter(Position + new Vector2(0, -1));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveCharacter(Position + new Vector2(-1, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveCharacter(Position + new Vector2(1, 0));
        }
    }

    public void MoveCharacter(Vector2 NextPosition)
    {
        // VÉRIFIER AVEC LE WORLD SI LA TILE EST TRAVERSABLE

        Tile tile = WorldManager.instance.GetTileAtPosition(NextPosition);
        if (tile && tile.CanGoThrough)
        {
            Position = NextPosition;
            transform.position = tile.transform.position;
        }
    }
}
