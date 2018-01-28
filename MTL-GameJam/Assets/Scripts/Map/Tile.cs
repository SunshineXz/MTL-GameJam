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
    public Exit TileExit;

    private void OnValidate()
    {
        transform.position = Position * 1.6f;
        
    }

    public bool CharacterCanGoThrough(Item characterItem)
    {
        bool CanGoThrough = false;
        
        if(TileType == TileTypeEnum.Ground)
        {
            if (TileDoor)
            {
                if (!TileDoor.isOpen && characterItem && characterItem.GetType() == typeof(Key))
                {
                    TileDoor.isOpen = true;
                    CanGoThrough = true;
                }
                else if(TileDoor.isOpen)
                {
                    CanGoThrough = true;
                }
                else
                {
                    CanGoThrough = false;
                }
            }
            else
            {
                CanGoThrough = true;
            }
        }
        else if (TileType == TileTypeEnum.Wall)
        {
            CanGoThrough = false;
        }
        else if (TileType == TileTypeEnum.Water)
        {
            if(characterItem && characterItem.GetType() == typeof(Umbrella))
            {
                CanGoThrough = true;
            }
            else
            {
                CanGoThrough = false;
            }
        }

        return CanGoThrough;
    }
}

