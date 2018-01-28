using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {
    public GameObject LightCharacter;
    public GameObject DarkCharacter;
    public GameObject Heart;
	// Use this for initialization
	void Awake () {
        Heart.SetActive(false);
	}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        if(Vector2.Distance(LightCharacter.transform.position, DarkCharacter.transform.position) >= 1.2f)
        {
            LightCharacter.transform.position = Vector2.MoveTowards(LightCharacter.transform.position, DarkCharacter.transform.position, 0.1f);
            DarkCharacter.transform.position = Vector2.MoveTowards(DarkCharacter.transform.position, LightCharacter.transform.position, 0.1f);
        }
        else
        {
            Heart.SetActive(true);
        }
    }
}
