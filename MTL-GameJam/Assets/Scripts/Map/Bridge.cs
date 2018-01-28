using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : Tile {
    public void Awake()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
