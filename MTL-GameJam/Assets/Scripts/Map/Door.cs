using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool isOpen;

	// Use this for initialization
	void Start () {
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenDoor(GameObject thisGameObject)
    {
        isOpen = true;
    }
}
