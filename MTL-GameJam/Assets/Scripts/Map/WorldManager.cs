using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour {
    public static WorldManager instance = null;

    private const int MAP_SIZE = 10;

    public GameObject Tiles;
    public PlayableCharacter Character;
    Tile[] tiles;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        tiles = GameObject.FindObjectsOfType<Tile>();
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Tile GetTileAtPosition(Vector2 position)
    {
        foreach(Tile tile in tiles){
            if(tile.Position == position)
            {
                return tile;
            }
        }
        return null;
    }
}
