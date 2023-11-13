using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileC : Tile
{
    protected override bool Check(Vector2 tileCoord)
    {
        bool canPlace = true;
        canPlace = base.Check(tileCoord);
        Tile x;
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 2, tileCoord.y + 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 2, tileCoord.y + 1)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x + 2, tileCoord.y + 1)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 2, tileCoord.y - 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 2, tileCoord.y - 1)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x + 2, tileCoord.y - 1)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 2, tileCoord.y + 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 2, tileCoord.y + 1)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x - 2, tileCoord.y + 1)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 2, tileCoord.y - 1), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 2, tileCoord.y - 1)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x - 2, tileCoord.y - 1)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 1, tileCoord.y + 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 1, tileCoord.y + 2)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x + 1, tileCoord.y + 2)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x + 1, tileCoord.y - 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x + 1, tileCoord.y - 2)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x + 1, tileCoord.y - 2)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 1, tileCoord.y + 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 1, tileCoord.y + 2)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x - 1, tileCoord.y + 2)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        if (Tile.tiles.TryGetValue(new Vector2(tileCoord.x - 1, tileCoord.y - 2), out x))
        {
            Tile.tiles[new Vector2(tileCoord.x - 1, tileCoord.y - 2)].HighlightTile();
            if (Tile.tiles[new Vector2(tileCoord.x - 1, tileCoord.y - 2)].tileType != TileType.Empty)
            {
                canPlace = false;
            }
        }
        return canPlace;
    }

    protected override void Uncheck(Vector2 tileCoord)
    {
        base.Uncheck(tileCoord);
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
}
