﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject Character;

    private Vector3 Offset;

	// Use this for initialization
	void Start () {
        if(Character)
            Offset = transform.position - Character.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(Character)
            transform.position = Character.transform.position + Offset;
	}

    public void SetCharacter(GameObject character)
    {
        Character = character;
    }
}
