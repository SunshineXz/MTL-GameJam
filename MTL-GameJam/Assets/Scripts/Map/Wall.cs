﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Placeable
{
    public bool isOpen;

    // Use this for initialization
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenWall()
    {
        isOpen = true;
        gameObject.GetComponent<Renderer>().enabled = false;
    }
}
