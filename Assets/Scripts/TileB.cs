using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileB : Tile
{
    protected override bool Check(Vector2 tileCoord)
    {
        bool canPlace = true;
        canPlace = base.Check(tileCoord);
        for (int i = 1; i < (isBigger(tileWidth - tileCoord.x, tileHeight - tileCoord.y) ? tileHeight - tileCoord.y : tileWidth - tileCoord.x); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y + i)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y + i)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        for (int i = 1; i < (isBigger(tileWidth - tileCoord.x - 1, tileCoord.y) ? tileCoord.y + 1 : tileWidth - tileCoord.x); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y - i)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y - i)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        for (int i = 1; i < (isBigger(tileCoord.x, tileCoord.y) ? tileCoord.y + 1 : tileCoord.x + 1); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y - i)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y - i)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        for (int i = 1; i < (isBigger(tileCoord.x, tileHeight - tileCoord.y - 1) ? tileHeight - tileCoord.y : tileCoord.x + 1); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y + i)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y + i)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        return canPlace;
    }

    protected override void Uncheck(Vector2 tileCoord)
    {
        base.Uncheck(tileCoord);
        for (int i = 0; i < (isBigger(tileWidth - tileCoord.x, tileHeight - tileCoord.y) ? tileHeight - tileCoord.y : tileWidth - tileCoord.x); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y + i)].unHighlightTile();
        }
        for (int i = 0; i < (isBigger(tileWidth - tileCoord.x - 1, tileCoord.y) ? tileCoord.y + 1 : tileWidth - tileCoord.x); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x + i, tileCoord.y - i)].unHighlightTile();
        }
        for (int i = 0; i < (isBigger(tileCoord.x, tileCoord.y) ? tileCoord.y + 1 : tileCoord.x + 1); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y - i)].unHighlightTile();
        }
        for (int i = 0; i < (isBigger(tileCoord.x, tileHeight - tileCoord.y - 1) ? tileHeight - tileCoord.y : tileCoord.x + 1); i++)
        {
            Tile.tiles[new Vector2(tileCoord.x - i, tileCoord.y + i)].unHighlightTile();
        }
    }
}
