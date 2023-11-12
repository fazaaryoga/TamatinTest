using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private Tile tilePrefab;
    [SerializeField] public int tileWidth = 5;
    [SerializeField] public int tileHeight = 5;
    [SerializeField] private GameObject cam;
    [SerializeField] private int startingTiles = 4;

    private Dictionary<Vector2, Tile> tileDict;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTiles();
    }

    private void Awake()
    {
        if (gameManager == null)
        {
            GameManager.gameManager = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateTiles()
    {
        Vector2[] randomCoordinates = new Vector2[startingTiles] ;
        for(int i = 0; i < startingTiles; i++)
        {
            Vector2 coord = new Vector2(Random.Range(0, tileWidth), Random.Range(0,tileHeight));
            while(Array.IndexOf(randomCoordinates, coord) > -1)
            {
                coord = new Vector2(Random.Range(0, tileWidth), Random.Range(0, tileHeight));
            }
            randomCoordinates[i] = coord;
        }

        tileDict = new Dictionary<Vector2, Tile>();
        int nameCounter = 0;
        for(int y = 0; y < tileHeight; y++)
        {
            for (int x = 0; x < tileWidth; x++)
            {
                Tile spawnedTile = Instantiate(tilePrefab, new Vector3(x, y, -1), Quaternion.identity);
                spawnedTile.name = "Tile " + nameCounter;
                nameCounter++;
                spawnedTile.tileCoord = new Vector2(x, y);
                if(Array.IndexOf(randomCoordinates, spawnedTile.tileCoord) > -1)
                {
                    spawnedTile.SetTile((Tile.TileType)Random.Range(1, 4));
                }
                else
                {
                spawnedTile.SetTile(Tile.TileType.Empty);
                }
                tileDict[new Vector2(x, y)] = spawnedTile;
            }
        }
        Tile.tiles = tileDict;

        cam.transform.position = new Vector3(tileWidth / 2f, tileHeight / 2f, -10);
    }
}
