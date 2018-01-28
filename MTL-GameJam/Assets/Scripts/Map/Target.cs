using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Placeable {
    public List<Bridge> bridges;

    public void ActiveBridge()
    {
        foreach(Bridge bridge in bridges)
        {
            bridge.OpenBridge();
        }
    }
}
