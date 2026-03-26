
using Microsoft.Xna.Framework;
using Tunnelnet.Components.World.Objects;
using Tunnelnet.Components.World.Tiles;

namespace Tunnelnet.Components.World.Gen;

public sealed class Chunk
{
    private static readonly byte chunkSize = 16;
    private Tile[,] _tiles;
    private Object[,] _objects;

    private Vector2 _chunkPosition;

    public Chunk(Vector2 position)
    {
        _chunkPosition = position;
        _tiles = new Tile[chunkSize, chunkSize];
        _objects = new Object[chunkSize, chunkSize];
    }

    public void Draw(Vector2 cameraPosition)
    {
        if((_chunkPosition.X * 16 - cameraPosition.X) * Object.tileSize + Object.aligmentValue.X > -16 * Object.tileSize &&
            (_chunkPosition.X * 16 - cameraPosition.X) * Object.tileSize + Object.aligmentValue.X < MainGame.Resolution.X
        )
        {
            if((_chunkPosition.Y * 16 - cameraPosition.Y) * Object.tileSize + Object.aligmentValue.Y > -16 * Object.tileSize &&
                (_chunkPosition.Y * 16 - cameraPosition.Y) * Tile.tileSize + Object.aligmentValue.Y < MainGame.Resolution.Y
            ){
                foreach (Tile tile in _tiles)
                {
                    tile?.Draw();
                }
                foreach (Object obj in _objects)
                {
                    obj?.Draw();
                }
            }
        }
    }

    public void Update(Vector2 cameraPosition)
    {
        if((_chunkPosition.X * 16 - cameraPosition.X) * Object.tileSize + Object.aligmentValue.X > -16 * Object.tileSize &&
            (_chunkPosition.X * 16 - cameraPosition.X) * Object.tileSize + Object.aligmentValue.X < MainGame.Resolution.X
        )
        {
            if((_chunkPosition.Y * 16 - cameraPosition.Y) * Object.tileSize + Object.aligmentValue.Y > -16 * Object.tileSize &&
                (_chunkPosition.Y * 16 - cameraPosition.Y) * Tile.tileSize + Object.aligmentValue.Y < MainGame.Resolution.Y
            ){
                foreach (Tile tile in _tiles)
                {
                    tile?.Update(cameraPosition);
                }
                foreach (Object obj in _objects)
                {
                    obj?.Update(cameraPosition);
                }
            }
        }
    }

    public void SetTile(byte x, byte y, Tile tile)
    {
        tile.Position = _chunkPosition * 16 + new Vector2(x, y);
        _tiles[y, x] = tile;
    }

    public void SetObject(byte x, byte y, Object obj)
    {
        obj.Position = _chunkPosition * 16 + new Vector2(x, y);
        _objects[y, x] = obj;
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

    public Object[,] Objects
    {
        get
        {
            return _objects;
        }
        set
        {
            _objects = value;
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