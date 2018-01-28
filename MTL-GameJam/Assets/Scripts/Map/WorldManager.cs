using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour {
    public static WorldManager instance = null;

    public int CurrentLevel = 0;

    private const int MAP_SIZE = 10;

    public CameraController CameraController;

    private GameObject CurrentWorld;
    public GameObject LightWorld;
    public GameObject DarkWorld;

    private PlayableCharacter CurrentCharacter;
    public PlayableCharacter LightCharacter;
    public PlayableCharacter DarkCharacter;

    enum World
    {
        Light,
        Dark
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        CurrentWorld = LightWorld;
        SetActiveTiles(World.Light);
        SetActiveCharacter(World.Light);
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWorld();
        }
        CheckEnd();
	}

    public Tile GetTileAtPosition(Vector2 position)
    {
        foreach(Tile tile in transform.Find(CurrentWorld.name).GetComponentsInChildren<Tile>())
        {
            if (tile.Position == position)
            {
                return tile;
            }
        }
        return null;
    }

    private void ChangeWorld()
    {
        if (CurrentWorld == LightWorld)
        {
            CurrentWorld = DarkWorld;
            SetActiveTiles(World.Dark);
            SetActiveCharacter(World.Dark);
        }
        else if (CurrentWorld == DarkWorld)
        {
            CurrentWorld = LightWorld;
            SetActiveTiles(World.Light);
            SetActiveCharacter(World.Light);
        }
    }

    private void SetActiveCharacter(World world)
    {
        switch (world)
        {
            case World.Light:
                CurrentCharacter = LightCharacter;
                LightCharacter.gameObject.GetComponent<Renderer>().enabled = true;
                LightCharacter.SetControlling(true);

                DarkCharacter.gameObject.GetComponent<Renderer>().enabled = false;
                DarkCharacter.SetControlling(false);
                break;
            case World.Dark:
                CurrentCharacter = DarkCharacter;
                LightCharacter.gameObject.GetComponent<Renderer>().enabled = false;
                LightCharacter.SetControlling(false);

                DarkCharacter.gameObject.GetComponent<Renderer>().enabled = true;
                DarkCharacter.SetControlling(true);
                break;
        }

        CameraController.SetCharacter(CurrentCharacter.gameObject);
    }

    private void SetActiveTiles(World world)
    {
        bool isLightActive = (world == World.Light) ? true : false;

        for (int i = 0; i < DarkWorld.transform.childCount; i++)
        {
            Transform tile = DarkWorld.transform.GetChild(i);
            tile.gameObject.SetActive(!isLightActive);
        }

        for (int i = 0; i < LightWorld.transform.childCount; i++)
        {
            Transform tile = LightWorld.transform.GetChild(i);
            tile.gameObject.SetActive(isLightActive);
        }
    }

    public PlayableCharacter GetCurrentCharacter()
    {
        return CurrentCharacter.GetComponent<PlayableCharacter>();
    }

    public GameObject GetCurrentWorld()
    {
        return CurrentWorld;
    }

    public GameObject GetOtherWorld()
    {
        return (CurrentWorld == LightWorld) ? DarkWorld : LightWorld;
    }

    public void CheckEnd()
    {
        if(LightCharacter.CheckEnd() && DarkCharacter.CheckEnd())
        {
            SceneManager.LoadScene(++CurrentLevel);
        }
    }
}
