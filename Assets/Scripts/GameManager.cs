using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private Tile[] tilePrefabs;
    [SerializeField] public int tileWidth = 5;
    [SerializeField] public int tileHeight = 5;
    [SerializeField] private GameObject cam;
    [SerializeField] private int startingTiles = 4;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] float timer = 6;
    [SerializeField] public int clicks = 3;

    public Queue<Tile> tilesToPlay = new Queue<Tile>();

    public float health = 3;
    private Dictionary<Vector2, Tile> tileDict;
    private float timeLeft;
    private int score = 0;
    private int clockTickTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timer;
        Tile.tileWidth = tileWidth;
        Tile.tileHeight = tileHeight;
        GenerateTiles();
        DisplayScore();
        DisplayHealth();
    }

    private void Update()
    {
        timeLeft = Mathf.Clamp(timeLeft - Time.deltaTime, 0, timer);
        DisplayTime(timeLeft);
        if (timeLeft <= 0) {
            ReduceHealth();
        }
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

    public void ProcessTile() {
        playPlaceSound();
        addTileToPlay();
        checkTiles();
        ResetTimer();
    }

    public void checkTiles()
    {
        Dictionary<int, List<Vector2>> tileCoordinates = new Dictionary<int, List<Vector2>>();
        for(int i = 1; i < tilePrefabs.Length; i++) {
            tileCoordinates[i] = new List<Vector2>();
        }

        foreach(KeyValuePair<Vector2, Tile> pair in tileDict)
        {
            if((int)pair.Value.tileType > 0)
            {
                tileCoordinates[(int)pair.Value.tileType].Add(pair.Key);
            }
        }

        foreach (KeyValuePair<int, List<Vector2>> pair in tileCoordinates)
        {
            if(pair.Value.Count == 4) {
                Debug.Log("key: " + pair.Key + " count: " + pair.Value.Count);
                addScore(tileDict[pair.Value[0]].score);
                Debug.Log(tileDict[pair.Value[0]].score);
                for(int i = 0; i < pair.Value.Count; i++)
                {
                    Tile newTile = Instantiate(tilePrefabs[0], new Vector3(pair.Value[i].x, pair.Value[i].y, -1), Quaternion.identity);
                    newTile.tileCoord = pair.Value[i];
                    tileDict[pair.Value[i]] = newTile;
                }
            }
        }
    }

    public void addTileToPlay()
    {
        int tileType = Random.Range(1, tilePrefabs.Length);
        Tile newTile = Instantiate(tilePrefabs[tileType], new Vector3(tileWidth + 2, tileHeight - 100, -1), Quaternion.identity);
        newTile.canClick = false;
        tilesToPlay.Enqueue(newTile);
        int iterator = 0;
        foreach(Tile tile in tilesToPlay) {
            tile.transform.position = new Vector3(tileWidth + 2, tileHeight - 6 + iterator, -1);
            iterator++;
        }
    }

    void addScore(int add)
    {
        Debug.Log("add score called");
        score += add;
        if(score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.SetText("Score: " + score);
    }

    public void ReduceHealth()
    {
        health--;
        playHurtSound();
        DisplayHealth();
        ResetTimer();
        if (health <= 0) { }
    }

    void ResetTimer()
    {
        timeLeft = timer;
    }

    void DisplayHealth()
    {
        HealthText.SetText("Health: " +  health);
    }

    void DisplayTime(float time)
    {
        int seconds = Mathf.FloorToInt(time);
        timerText.SetText("Time left: " + seconds);
        if (seconds != clockTickTimer) {
            playClockSound();
            clockTickTimer = seconds;
        }
    }

    void playClockSound()
    {
        audio.clip = sounds[2];
        audio.Play();
    }

    public void playPlaceSound()
    {
        audio.clip = sounds[0];
        audio.Play();
    }

    public void playHurtSound()
    {
        audio.clip = sounds[1];
        audio.PlayOneShot(audio.clip);
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
        Tile.tiles = tileDict;
        int nameCounter = 0;
        for(int y = 0; y < tileHeight; y++)
        {
            for (int x = 0; x < tileWidth; x++)
            {
                Tile spawnedTile;
                if(Array.IndexOf(randomCoordinates, new Vector2(x,y)) > -1)
                {
                    spawnedTile = Instantiate(tilePrefabs[Random.Range(1, tilePrefabs.Length)], new Vector3(x, y, -1), Quaternion.identity);
                }
                else
                {
                    spawnedTile = Instantiate(tilePrefabs[0], new Vector3(x, y, -1), Quaternion.identity);
                }
                spawnedTile.InitializeTile("Tile" + nameCounter, new Vector2(x, y));
                nameCounter++;
            }
        }

        cam.transform.position = new Vector3(tileWidth / 2f, tileHeight / 2f, -10);

        for(int i = 0;i < 4; i++)
        {
            int tileType = Random.Range(1, tilePrefabs.Length);
            Tile tile = Instantiate(tilePrefabs[tileType], new Vector3(tileWidth + 2, tileHeight - 5 + i, -1), Quaternion.identity);
            tile.canClick = false;
            tilesToPlay.Enqueue(tile);
        }
    }
}
