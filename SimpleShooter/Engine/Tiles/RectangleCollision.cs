using Microsoft.Xna.Framework;
using SimpleShooter.Engine;
using SimpleShooter.Engine.Characters;
using System;
using System.Collections.Generic;
using static SimpleShooter.Engine.Collidable_tile;

namespace SimpleShooter.Engine.Tiles
{
    public class CollisionDetectionSystem
    {
        Map map;
        public CollisionDetectionSystem(Map map)
        {
            this.map = map;
        }
        public List<(CollisionSide, float)> CheckCollision(Entity entity)
        {
            Rectangle new_player_region_occupied = new Rectangle((int)(entity.pos.X + entity.NextMove.X), (int)(entity.pos.Y + entity.NextMove.Y + map.shift.value.Y), (int)entity.dim.X, (int)entity.dim.Y);

            List<Collidable_tile> tiles_in_region = new();

            foreach (Tile item in Tiles_in_that_region(new Rectangle((int)(new_player_region_occupied.X / map.tile_size.X), (int)(new_player_region_occupied.Y / map.tile_size.Y), 
                (int)(entity.dim.X / map.tile_size.X), (int)(entity.dim.Y / map.tile_size.Y))))
            {
                if (item is Collidable_tile)
                {
                    tiles_in_region.Add((Collidable_tile)item);
                }
            }
            List<(CollisionSide, float)> collision_sides = new();

            foreach (Collidable_tile tile in tiles_in_region)
            {
                Rectangle new_player_collision_box = entity.collsion_box;
                Rectangle tile_collision_box = tile.colision_region;
                collision_sides.AddRange(EntityCollision(tile, new_player_collision_box, entity.NextMove));
            }
            return collision_sides;
        }
            
        
        public List<(CollisionSide, float)> CheckCollision(Player player)
        {
            Rectangle new_player_region_occupied = new Rectangle((int)(player.pos.X + player.NextMove.X + map.shift.value.X), (int)(player.pos.Y + player.NextMove.Y + map.shift.value.Y), (int)player.dim.X, (int)player.dim.Y);

            List<Collidable_tile> tiles_in_region = new();

            foreach (Tile item in Tiles_in_that_region(new Rectangle((int)(new_player_region_occupied.X / map.tile_size.X), (int)(new_player_region_occupied.Y / map.tile_size.Y), (int)(player.dim.X / map.tile_size.X), (int)(player.dim.Y / map.tile_size.Y))))
            {
                if (item is Collidable_tile)
                {
                    tiles_in_region.Add((Collidable_tile)item);
                }
            }
            List<(CollisionSide, float)> collision_sides = new();

            foreach (Collidable_tile tile in tiles_in_region)
            {
                Rectangle new_player_collision_box = player.player_collision_box;
                Rectangle tile_collision_box = tile.colision_region;
                collision_sides.AddRange(EntityCollision(tile, new_player_collision_box, player.NextMove));
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
                    if (map.tiles_copy.TryGetValue(new Point(x, y), out Tile e))
                    {
                        tiles_in_region.Add(e);
                    }

                }
            }
            return tiles_in_region;
        }
        public List<(CollisionSide, float)> EntityCollision(Collidable_tile e, Rectangle entity_hitbox, Vector2 Movement)
        {
            List<(CollisionSide, float)> sides = new List<(CollisionSide, float)>(2);
            SharpDX.RectangleF new_region = new SharpDX.RectangleF(e.colision_region.X, e.colision_region.Y, e.colision_region.Width, e.colision_region.Height);
            SharpDX.RectangleF new_entity_hitbox = new SharpDX.RectangleF(entity_hitbox.X, entity_hitbox.Y, entity_hitbox.Width, e.colision_region.Height);

            new_entity_hitbox.X += Movement.X;
            new_entity_hitbox.Y += Movement.Y;

            new_region.X -= map.shift.value.X;
            new_region.Y -= map.shift.value.Y;

            CollisionSide CollsionSide = CollisionSide.None;
            if (new_region.Intersects(new_entity_hitbox))
            {
                new_entity_hitbox.X -= Movement.X;

                if (new_region.Intersects(new_entity_hitbox))
                {
                    CollsionSide = Movement.Y > 0 ? CollisionSide.Bottom : CollisionSide.Top;
                    new_entity_hitbox.Y -= Movement.Y;
                    sides.Add((CollsionSide, dystanse_for_that_side(CollsionSide, new_entity_hitbox, new_region)));

                }

                new_entity_hitbox.X += Movement.X;
                new_entity_hitbox.Y -= Movement.Y;

                if (new_region.Intersects(new_entity_hitbox))
                {
                    CollsionSide = Movement.X > 0 ? CollisionSide.Right : CollisionSide.Left;
                    new_entity_hitbox.X -= Movement.X;
                    sides.Add((CollsionSide, dystanse_for_that_side(CollsionSide, new_entity_hitbox, new_region)));

                }

            }

            return sides;
        }

        private float dystanse_for_that_side(CollisionSide collsion_side, SharpDX.RectangleF entity_hitbox, SharpDX.RectangleF tile_hitbox)
        {

            switch (collsion_side)
            {
                case CollisionSide.Top:
                    float dystanse_between_top_side = Math.Max(0, tile_hitbox.Top - tile_hitbox.Bottom);
                    return dystanse_between_top_side;

                case CollisionSide.Bottom:
                    float dystanse_between_bottom_side = Math.Max(0, tile_hitbox.Top - tile_hitbox.Bottom);
                    return dystanse_between_bottom_side;

                case CollisionSide.Right:
                    float dystanse_between_left_side = Math.Max(0, entity_hitbox.Right - tile_hitbox.Left);
                    return dystanse_between_left_side;

                case CollisionSide.Left:
                    float dystanse_between_right_side = Math.Max(0, tile_hitbox.Left - entity_hitbox.Right);
                    return dystanse_between_right_side;
            }
            return 0;
            //int dystanse_between_bottom_side = tile_hitbox.Center.Y - entity_hitbox.Center.Y - entity_hitbox.Height / 2 - tile_hitbox.Height / 2;
        }
    }
}