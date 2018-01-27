using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TileTypeEnum
{
    Wall,
    Grass
}


public class Tile : MonoBehaviour
{
    public TileTypeEnum TileType;
    public Vector2 Position;
    public bool CanGoThrough;
    public Image TileImage;

    private void OnValidate()
    {
        transform.position = Position * 1.6f;
        
    }
}

