using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Placeable {

    public bool isOpen = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenDoor()
    {
        isOpen = true;
        gameObject.SetActive(false);
    }
}
