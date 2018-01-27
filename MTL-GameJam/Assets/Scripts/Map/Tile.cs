using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TileTypeEnum
{
    Wall,
    Grass,
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

    private void OnValidate()
    {
        transform.position = Position * 1.6f;
        
    }

    public bool CaracterCanGoThrough()
    {
        return (CanGoThrough && ((TileDoor != null) ? TileDoor.isOpen : true));
    }
}

