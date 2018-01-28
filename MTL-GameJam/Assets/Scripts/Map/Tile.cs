using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TileTypeEnum
{
    Wall,
    Ground,
    Water
}


public class Tile : MonoBehaviour
{
    public TileTypeEnum TileType;
    public Vector2 Position;
    public bool CanGoThrough;
    public Image TileImage;
    public Door TileDoor;
    public Item TileItem;
    public Target Target;

    private void OnValidate()
    {
        transform.position = Position * 1.6f;
        
    }

    public bool CharacterCanGoThrough(Item characterItem)
    {
        bool CanGoThrough = false;
        if(TileDoor)
        {
            if (!TileDoor.isOpen && characterItem.GetType() == typeof(Key))
            {
                TileDoor.isOpen = true;
                CanGoThrough = true;
            }
            else
            {
                CanGoThrough = false;
            }
        }
        else if(TileType == TileTypeEnum.Ground)
        {
            CanGoThrough = true;
        }
        return CanGoThrough;
    }
}

