﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : Placeable {

	// Use this for initialization
	void Start () {
		
	}

    private void OnValidate()
    {
        transform.position = Position * 1.6f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Position * 1.6f;
    }
}
