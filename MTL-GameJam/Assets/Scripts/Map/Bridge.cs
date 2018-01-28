using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : Placeable
{

    public bool isOpen = false;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(isOpen);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenBridge()
    {
        isOpen = true;
        gameObject.SetActive(true);
    }
}
