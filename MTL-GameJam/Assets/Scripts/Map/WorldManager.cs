using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance = null;

    private const int MAP_SIZE = 10;

    public GameObject LightWorld;
    public GameObject DarkWorld;

    private GameObject CurrentWorld;
    public PlayableCharacter Character;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        CurrentWorld = LightWorld;
        SetActiveTiles(true);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWorld();
        }
    }

    public Tile GetTileAtPosition(Vector2 position)
    {
        foreach (Tile tile in transform.Find(CurrentWorld.name).GetComponentsInChildren<Tile>())
        {
            if (tile.Position == position)
            {
                return tile;
            }
        }
        return null;
    }

    public void ChangeWorld()
    {
        if (CurrentWorld == LightWorld)
        {
            CurrentWorld = DarkWorld;
            SetActiveTiles(false);
        }
        else if (CurrentWorld == DarkWorld)
        {
            CurrentWorld = LightWorld;
            SetActiveTiles(true);
        }
    }

    public void SetActiveTiles(bool isLightActive)
    {
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
}
