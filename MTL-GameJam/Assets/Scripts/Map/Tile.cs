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


public class Tile : Placeable
{
    public TileTypeEnum TileType;
    public Image TileImage;
    public Door TileDoor;
    public Item TileItem;
    public Target Target;
    public Exit TileExit;
    public Wall wall;
    public Bridge bridge;

    public bool CharacterCanGoThrough(Item characterItem)
    {
        bool CanGoThrough = false;

        if (TileType == TileTypeEnum.Ground)
        {
            if (TileDoor)
            {
                if (!TileDoor.isOpen && characterItem && characterItem.GetType() == typeof(Key))
                {
                    TileDoor.isOpen = true;
                    CanGoThrough = true;
                }
                else if (TileDoor.isOpen)
                {
                    CanGoThrough = true;
                }
                else
                {
                    CanGoThrough = false;
                }
            }
            else if (wall)
            {
                CanGoThrough = wall.isOpen;
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
            if (characterItem && characterItem.GetType() == typeof(Umbrella))
            {
                CanGoThrough = true;
            }
            else if(bridge)
            {
                CanGoThrough = bridge.isOpen;
            }
            else
            {
                CanGoThrough = false;
            }
        }

        if ((wall && wall.isOpen) || (bridge && bridge.isOpen))
        {
            CanGoThrough = true;
        }

        return CanGoThrough;
    }
}

