using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Tile {
    public Sprite pressedSprite;
    public List<Wall> walls;

    public void PressButton()
    {
        GetComponent<SpriteRenderer>().sprite = pressedSprite;
        foreach(Wall wall in walls)
        {
            wall.OpenWall();
        }
    }
}
