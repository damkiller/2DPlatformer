using Microsoft.Xna.Framework;
using SimpleShooter.Engine.Characters;
using SimpleShooter.Engine.Utilities;
using System.Collections.Generic;
using static SimpleShooter.Engine.Collidable_tile;

namespace SimpleShooter.Engine
{
    public class Map
    {

        Dictionary<Point, Tile> tiles = new();
        public Vector2 tile_size = new(32, 32);
        public Vector2 scale = new(1, 1);
        public Box<Vector2> shift;
         public Map(Box<Vector2> shift)
        {
            this.shift = shift;

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
        public List<(CollisionSide, int)> CheckCollision(Player player)
        {
            Rectangle new_player_region_occupied = new Rectangle((int)(player.pos.X + player.NextMove.X + shift.value.X), (int)(player.pos.Y + player.NextMove.Y + shift.value.Y), (int)player.dim.X, (int)player.dim.Y);

            List<Collidable_tile> tiles_in_region = new();

            foreach (Tile item in Tiles_in_that_region(new Rectangle((int)(new_player_region_occupied.X / tile_size.X), (int)(new_player_region_occupied.Y / tile_size.Y), (int)(player.dim.X / tile_size.X), (int)(player.dim.Y / tile_size.Y))))
            {
                if (item is Collidable_tile)
                {
                    tiles_in_region.Add((Collidable_tile)item);
                }
            }
            List<(CollisionSide, int)> collision_sides = new();

            foreach (Collidable_tile tile in tiles_in_region)
            {
                Rectangle new_player_collision_box = player.player_collision_box;

               (CollisionSide,int) e = EntityCollision(tile, new_player_collision_box, player.NextMove);

                if (e.Item1 == CollisionSide.None)
                {
                    continue;
                }

                collision_sides.Add(e);
            }
            return collision_sides;
        }
        public List<Tile> Tiles_in_that_region(Rectangle grid_size_region)
        {
            List<Tile> tiles_in_region = new List<Tile>();
            for (int y = grid_size_region.Y; y <= grid_size_region.Y + grid_size_region.Height; y++)
            {
                for (int x = grid_size_region.X; x <= grid_size_region.X + grid_size_region.Width; x++)
                {
                    if (tiles.TryGetValue(new Point(x, y), out Tile e)) 
                    {
                        tiles_in_region.Add(e);
                    }

                }

            }
            return tiles_in_region;
        }
        public (CollisionSide, int) EntityCollision(Collidable_tile e, Rectangle entity_hitbox, Vector2 Movement)
        {
            Rectangle new_region = e.colision_region;

            entity_hitbox.X += (int)Movement.X;
            entity_hitbox.Y += (int)Movement.Y;

            new_region.X -= (int)shift.value.X;
            new_region.Y -= (int)shift.value.Y;

            CollisionSide CollsionSide;

                if (new_region.Intersects(entity_hitbox))
                {
                    entity_hitbox.X -= (int)Movement.X;

                   if (new_region.Intersects(entity_hitbox))
                   {
                    CollsionSide = Movement.Y > 0 ? CollisionSide.Bottom : CollisionSide.Top;
                    entity_hitbox.Y -= (int)Movement.Y;
                    return (CollsionSide, dystanse_for_that_side(CollsionSide, entity_hitbox, new_region));

                   }

                     entity_hitbox.X += (int)Movement.X;
                     entity_hitbox.Y -= (int)Movement.Y;

                   if (new_region.Intersects(entity_hitbox))
                   {
                    CollsionSide = Movement.X > 0 ? CollisionSide.Right : CollisionSide.Left;
                    entity_hitbox.X -= (int)Movement.X;
                    return (CollsionSide, dystanse_for_that_side(CollsionSide, entity_hitbox, new_region));

                   }

                }
  
            return (CollisionSide.None, 0);
        }

        private int dystanse_for_that_side(CollisionSide collsion_side, Rectangle entity_hitbox, Rectangle tile_hitbox)
        {
            switch (collsion_side)
            {
                case CollisionSide.Top:
                    int dystanse_between_top_side = entity_hitbox.Center.Y - tile_hitbox.Center.Y - entity_hitbox.Height / 2 - tile_hitbox.Height / 2;
                    return dystanse_between_top_side > 0 ? dystanse_between_top_side : 0;

                case CollisionSide.Bottom:
                    int dystanse_between_bottom_side = tile_hitbox.Center.Y - entity_hitbox.Center.Y - entity_hitbox.Height / 2 - tile_hitbox.Height / 2;
                    return dystanse_between_bottom_side > 0 ? dystanse_between_bottom_side : 0;

                case CollisionSide.Left:
                    int dystanse_between_left_side = entity_hitbox.Center.X - tile_hitbox.Center.X - entity_hitbox.Width / 2 - tile_hitbox.Width / 2;
                    return dystanse_between_left_side > 0 ? dystanse_between_left_side : 0;

                case CollisionSide.Right:
                    int dystanse_between_right_side = tile_hitbox.Center.X - entity_hitbox.Center.X - entity_hitbox.Width / 2 - tile_hitbox.Width / 2;
                    return dystanse_between_right_side > 0 ? dystanse_between_right_side : 0;
            }
            return 0;
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
                //Rectangle tileregion = new Rectangle((int)(tile.Key.X * tile_size.X - shift.value.X), (int)(tile.Key.Y * tile_size.Y - shift.value.Y), (int)(tile_size.X * scale.X), (int)(tile_size.Y * scale.Y));
                //tileregion.Draw(Color.Red);
            }
        }




    }
}
