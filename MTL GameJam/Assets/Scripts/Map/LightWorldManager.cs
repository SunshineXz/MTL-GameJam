using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightWorld : MonoBehaviour {

    private const int MAP_SIZE = 10;

    public GameObject TilePrefab;
    List<List<Tile>> Map = new List<List<Tile>>();

	// Use this for initialization
	void Start () {
        GenerateMap();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void GenerateMap()
    {
        Map = new List<List<Tile>>();
        for(int i = 0; i < MAP_SIZE; i++)
        {
            List<Tile> Row = new List<Tile>();
            for(int j = 0; j < MAP_SIZE; j++)
            {
                Tile Tile = Instantiate(TilePrefab, new Vector2(i * 32,j * 32), Quaternion.identity).GetComponent<Tile>();
            }
        }
    }
}
