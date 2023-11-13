using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum TileType { Empty, A, B, C };

    public TileType tileType = TileType.Empty;
    public static Dictionary<Vector2, Tile> tiles;
    public Vector2 tileCoord;
    public bool canClick = true;

    [SerializeField] GameObject canPlaceHighlight;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    [SerializeField] public int score = 0;

    public static int tileWidth;
    public static int tileHeight;
    protected virtual bool Check(Vector2 tileCoord) {
        if (tiles[tileCoord].tileType != TileType.Empty) {
            return false;
        }
        else
        {
            return true;
        }
    }
        
    protected virtual void Uncheck(Vector2 tileCoord) {
    }

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if (canClick)
        {
        GameManager.gameManager.tilesToPlay.Peek().Check(tileCoord);
        }
    }

    private void OnMouseExit()
    {
        if (canClick)
        {
            GameManager.gameManager.tilesToPlay.Peek().Uncheck(tileCoord);
        
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.gameManager.tilesToPlay.Peek().Check(tileCoord))
        {
            GameManager.gameManager.tilesToPlay.Peek().Uncheck(tileCoord);
            SetTile();
        }
        else
        {
            GameManager.gameManager.ReduceHealth();
        }
    }
    public void SetTile()
    {
        Tile newTile = GameManager.gameManager.tilesToPlay.Dequeue();
        newTile.InitializeTile(gameObject.name, tileCoord);
        newTile.transform.position = new Vector3(tileCoord.x, tileCoord.y, -1);
        Tile.tiles[tileCoord].canClick = true;
        GameManager.gameManager.ProcessTile();
        Destroy(gameObject);
    }

    public void HighlightTile()
    {
        canPlaceHighlight.SetActive(true);
    }

    public void unHighlightTile()
    {
        canPlaceHighlight.SetActive(false);
    }

    protected bool isBigger(float x, float y)
    {
        if(x >= y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void InitializeTile(string name, Vector2 tileCoord)
    {
        this.name = name;
        this.tileCoord = tileCoord;
        tiles[tileCoord] = this;
    }
}
