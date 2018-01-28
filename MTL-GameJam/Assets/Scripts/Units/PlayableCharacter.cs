using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}

public class PlayableCharacter : Character
{
    public Item PickedItem;
    bool Moving = false;
    bool Controlling = false;
    Direction direction;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ReactToUserInput();
        MoveCharacter();
    }

    public bool CheckEnd()
    {
        TileDestination = WorldManager.instance.GetTileAtPosition(Position);
        if (TileDestination && TileDestination.TileExit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ReactToUserInput()
    {
        if (Moving || !Controlling)
            return;

        if (Input.GetKey(KeyCode.W))
        {
            SetNextPosition(Position + new Vector2(0, 1));
            direction = Direction.Up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            SetNextPosition(Position + new Vector2(0, -1));
            direction = Direction.Down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            SetNextPosition(Position + new Vector2(-1, 0));
            direction = Direction.Left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            SetNextPosition(Position + new Vector2(1, 0));
            direction = Direction.Right;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            DropItem();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (PickedItem != null)
            {
                PickedItem.Use();
            }
        }
    }

    public void SetNextPosition(Vector2 nextPosition)
    {
        // VÉRIFIER AVEC LE WORLD SI LA TILE EST TRAVERSABLE

        TileDestination = WorldManager.instance.GetTileAtPosition(nextPosition);
        if (TileDestination && TileDestination.TileDoor && !TileDestination.TileDoor.isOpen)
        {
            if (PickedItem && PickedItem.GetType() == typeof(Key))
            {
                TileDestination.TileDoor.OpenDoor();
                PickedItem = null;
            }
        }
        if (TileDestination && TileDestination.CharacterCanGoThrough(PickedItem))
        {
            if (TileDestination.GetType() == typeof(Button))
            {
                ((Button)TileDestination).PressButton();
            }
            if (TileDestination.TileItem && !PickedItem)
            {
                PickedItem = TileDestination.TileItem;
                TileDestination.TileItem = null;
                PickedItem.gameObject.GetComponent<Renderer>().enabled = false;

                if (TileDestination.GetType() == typeof(Portal))
                {
                    Portal LinkedPortal = ((Portal)TileDestination).LinkedPortal;
                    LinkedPortal.TileItem.gameObject.GetComponent<Renderer>().enabled = false;
                    LinkedPortal.TileItem = null;
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

        if (Vector3.Distance(transform.position, TileDestination.transform.position) <= 0.1f)
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
            if (tile.GetType() == typeof(Portal))
            {
                PickedItem = ((Portal)tile).SwitchItem(PickedItem);
            }
            else if (!tile.TileItem && tile.TileType == TileTypeEnum.Ground)
            {
                PickedItem.Position = tile.Position;
                tile.TileItem = PickedItem;
                tile.TileItem.gameObject.GetComponent<Renderer>().enabled = true;
                PickedItem = null;
            }
        }
    }

    public void SetControlling(bool controlling)
    {
        Controlling = controlling;
    }

    public Item GetPickedItem()
    {
        return PickedItem;
    }

    public Direction GetDirection()
    {
        return direction;
    }
}
