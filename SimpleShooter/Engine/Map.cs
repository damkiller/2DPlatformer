using Microsoft.Xna.Framework;
using SimpleShooter.Engine.Characters;
using SimpleShooter.Engine.Tiles;
using SimpleShooter.Engine.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using static SimpleShooter.Engine.Collidable_tile;

namespace SimpleShooter.Engine
{
    public class Map
    {

        Dictionary<Point, Tile> tiles = new();
        public Dictionary<Point, Tile> tiles_copy => new(tiles);
        public Vector2 tile_size = new(32, 32);
        public Vector2 scale = new(1, 1);
        public Box<Vector2> shift;
        public CollisionDetectionSystem collisionDetectionSystem;
         public Map(Box<Vector2> shift)
        {
            this.shift = shift;
            collisionDetectionSystem = new CollisionDetectionSystem(this);

        }
        public Tile this[int x, int y]
        {
            get
            {
                if (tiles.TryGetValue(new Point(x, y), out Tile t))
                {
                    return t;
                }
                return null;
            }
            set
            {
                if (value is Collidable_tile)
                {
                    Collidable_tile e = (Collidable_tile)value;
                    if (e.colision_region == default)
                    {
                        e.colision_region = new Rectangle((int)(x * tile_size.X), (int)(y * tile_size.Y), (int)tile_size.X, (int)tile_size.Y);
                    }
                    else
                    {
                        e.colision_region = new Rectangle((int)(x * tile_size.X) + e.colision_region.X, (int)(y * tile_size.Y) + e.colision_region.Y, e.colision_region.Width, e.colision_region.Height);
                    }
                }
                AddTile(value, new Point(x, y));
            }
        }


        public void AddTile(Tile tile, Point point)
        {
            if (tiles.ContainsKey(point))
            {
                tiles[point] = tile;
                return;
            }
            tiles.Add(point, tile);
        }
        public void Draw()
        {
            foreach (var tile in tiles)
            {
                 tile.Value.Draw(new Vector2(tile.Key.X * tile_size.X - shift.value.X, tile.Key.Y * tile_size.Y - shift.value.Y), new Vector2(tile_size.X * scale.X, tile_size.Y * scale.Y));
                Rectangle tileregion = new Rectangle((int)(tile.Key.X * tile_size.X - shift.value.X), (int)(tile.Key.Y * tile_size.Y - shift.value.Y), (int)(tile_size.X * scale.X), (int)(tile_size.Y * scale.Y));
                tileregion.Draw(Color.Red);
            }
        }




    }
}
