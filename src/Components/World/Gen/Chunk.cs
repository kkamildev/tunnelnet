
using Microsoft.Xna.Framework;
using Tunnelnet.Components.World.Tiles;

namespace Tunnelnet.Components.World.Gen;

public sealed class Chunk
{
    private static readonly byte chunkSize = 16;
    private Tile[,] _tiles;

    private Vector2 _chunkPosition;

    public Chunk(Vector2 position)
    {
        _chunkPosition = position;
        _tiles = new Tile[chunkSize, chunkSize];
    }

    public void Draw(Vector2 cameraPosition)
    {
        if((_chunkPosition.X * 16 - cameraPosition.X) * Tile.tileSize + Tile.aligmentValue.X > -16 * Tile.tileSize &&
            (_chunkPosition.X * 16 - cameraPosition.X) * Tile.tileSize + Tile.aligmentValue.X < MainGame.Resolution.X
        )
        {
            if((_chunkPosition.Y * 16 - cameraPosition.Y) * Tile.tileSize + Tile.aligmentValue.Y > -16 * Tile.tileSize &&
                (_chunkPosition.Y * 16 - cameraPosition.Y) * Tile.tileSize + Tile.aligmentValue.Y < MainGame.Resolution.Y
            ){
                foreach (Tile tile in _tiles)
                {
                    tile?.Draw();
                }
            }
        }
    }

    public void Update(Vector2 cameraPosition)
    {
        if((_chunkPosition.X * 16 - cameraPosition.X) * Tile.tileSize + Tile.aligmentValue.X > -16 * Tile.tileSize &&
            (_chunkPosition.X * 16 - cameraPosition.X) * Tile.tileSize + Tile.aligmentValue.X < MainGame.Resolution.X
        )
        {
            if((_chunkPosition.Y * 16 - cameraPosition.Y) * Tile.tileSize + Tile.aligmentValue.Y > -16 * Tile.tileSize &&
                (_chunkPosition.Y * 16 - cameraPosition.Y) * Tile.tileSize + Tile.aligmentValue.Y < MainGame.Resolution.Y
            ){
                foreach (Tile tile in _tiles)
                {
                    tile?.Update(cameraPosition);
                }
            }
        }
    }

    public void SetTile(byte x, byte y, Tile tile)
    {
        tile.Position = _chunkPosition * 16 + new Vector2(x, y);
        _tiles[y, x] = tile;
    }


    public Tile[,] Tiles
    {
        get
        {
            return _tiles;
        }
        set
        {
            _tiles = value;
        }
    }

    public Vector2 ChunkPosition
    {
        get
        {
            return _chunkPosition;
        }
    }
}