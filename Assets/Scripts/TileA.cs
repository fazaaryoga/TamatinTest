using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileA : Tile
{

    protected override bool Check(Vector2 tileCoord)
    {
        bool canPlace = true;
        canPlace = base.Check(tileCoord);
        for (int i = 0; i < tileWidth; i++)
        {
            if (i != tileCoord.x)
            {
                Tile.tiles[new Vector2(i, tileCoord.y)].HighlightTile();
                if (Tile.tiles[new Vector2(i, tileCoord.y)].tileType != TileType.Empty)
                {
                    canPlace = false;
                }
            }
        }
        for (int i = 0; i < tileHeight; i++)
        {
            if (i != tileCoord.y)
            {
                Tile.tiles[new Vector2(tileCoord.x, i)].HighlightTile();
                if (Tile.tiles[new Vector2(tileCoord.x, i)].tileType != TileType.Empty)
                {
                    canPlace = false;
                }
            }
        }
        Debug.Log(canPlace);
        return canPlace;
    }

    protected override void Uncheck(Vector2 tileCoord) {
        base.Uncheck(tileCoord);
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
}
