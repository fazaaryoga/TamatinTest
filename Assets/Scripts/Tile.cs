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

    [SerializeField] GameObject canPlaceHighlight;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;

    private static int tileWidth;
    private static int tileHeight;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        tileWidth = GameManager.gameManager.tileWidth;
        tileHeight = GameManager.gameManager.tileHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        //checkRook();
        //checkBishop();
        checkKnight();
    }

    private void OnMouseExit()
    {
        //uncheckRook();
        //uncheckBishop();
        uncheckKnight();
    }

    private void OnMouseDown()
    {
        SetTile(TileType.B);
    }

    public void SetTile(TileType tileType)
    {
        this.tileType = tileType;
        spriteRenderer.sprite = sprites[(int)tileType];
    }

    public void HighlightTile()
    {
        canPlaceHighlight.SetActive(true);
    }

    public void unHighlightTile()
    {
        canPlaceHighlight.SetActive(false);
    }

    public void checkRook()
    {
        for (int i = 0; i < tileWidth; i++)
        {
            if(i != tileCoord.x)
            {
                Tile.tiles[new Vector2(i, tileCoord.y)].HighlightTile();
            }
        }
        for (int i = 0; i < tileHeight; i++)
        {
            if (i != tileCoord.y)
            {
                Tile.tiles[new Vector2(tileCoord.x, i)].HighlightTile();
            }
        }
    }

    public void uncheckRook()
    {
        for (int i = 0; i < tileWidth; i++)
        {
            if (i != tileCoord.x)
            {
                Tile.tiles[new Vector2(i, tileCoord.y)].unHighlightTile();
            }
        }
        for (int i = 0; i < tileHeight; i++)
        {
            if (i != tileCoord.y)
            {
                Tile.tiles[new Vector2(tileCoord.x, i)].unHighlightTile();
            }
        }
    }

    public void checkBishop()
    {
        for(int i = 1; i < (isBigger(tileWidth - tileCoord.x, tileHeight - tileCoord.y) ? tileHeight - tileCoord.y : tileWidth - tileCoord.x); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y + i)].HighlightTile();
        }
        for (int i = 1; i < (isBigger(tileWidth - tileCoord.x -1, tileCoord.y) ? tileCoord.y + 1 : tileWidth - tileCoord.x); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y - i)].HighlightTile();
        }
        for (int i = 1; i < (isBigger(tileCoord.x, tileCoord.y) ? tileCoord.y + 1 : tileCoord.x + 1); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y - i)].HighlightTile();
        }
        for (int i = 1; i < (isBigger(tileCoord.x, tileHeight - tileCoord.y - 1) ? tileHeight - tileCoord.y : tileCoord.x + 1); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y + i)].HighlightTile();
        }

    }

    public void uncheckBishop()
    {
        for (int i = 1; i < (isBigger(tileWidth - tileCoord.x, tileHeight - tileCoord.y) ? tileHeight - tileCoord.y : tileWidth - tileCoord.x); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y + i)].unHighlightTile();
        }
        for (int i = 1; i < (isBigger(tileWidth - tileCoord.x - 1, tileCoord.y) ? tileCoord.y + 1 : tileWidth - tileCoord.x); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y - i)].unHighlightTile();
        }
        for (int i = 1; i < (isBigger(tileCoord.x, tileCoord.y) ? tileCoord.y + 1 : tileCoord.x + 1); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y - i)].unHighlightTile();
        }
        for (int i = 1; i < (isBigger(tileCoord.x, tileHeight - tileCoord.y - 1) ? tileHeight - tileCoord.y : tileCoord.x + 1); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y + i)].unHighlightTile();
        }

    }

    public void checkKnight()
    {
        Tile x;
        if(Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 2, tileCoord.y + 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 2, tileCoord.y + 1)].HighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 2, tileCoord.y - 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 2, tileCoord.y - 1)].HighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 2, tileCoord.y + 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 2, tileCoord.y + 1)].HighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 2, tileCoord.y - 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 2, tileCoord.y - 1)].HighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 1, tileCoord.y + 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 1, tileCoord.y + 2)].HighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 1, tileCoord.y - 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 1, tileCoord.y - 2)].HighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 1, tileCoord.y + 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 1, tileCoord.y + 2)].HighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 1, tileCoord.y - 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 1, tileCoord.y - 2)].HighlightTile();
        }
    }

    public void uncheckKnight()
    {
        Tile x;
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 2, tileCoord.y + 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 2, tileCoord.y + 1)].unHighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 2, tileCoord.y - 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 2, tileCoord.y - 1)].unHighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 2, tileCoord.y + 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 2, tileCoord.y + 1)].unHighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 2, tileCoord.y - 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 2, tileCoord.y - 1)].unHighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 1, tileCoord.y + 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 1, tileCoord.y + 2)].unHighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 1, tileCoord.y - 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 1, tileCoord.y - 2)].unHighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 1, tileCoord.y + 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 1, tileCoord.y + 2)].unHighlightTile();
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 1, tileCoord.y - 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 1, tileCoord.y - 2)].unHighlightTile();
        }
    }

    private bool isBigger(float x, float y)
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
}
