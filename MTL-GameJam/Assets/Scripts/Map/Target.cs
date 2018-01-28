using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Tile {
    public List<Bridge> bridges;

    public void ActiveBridge()
    {
        foreach(Bridge bridge in bridges)
        {
            bridge.gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
