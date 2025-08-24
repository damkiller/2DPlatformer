
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine
{
    public class Collidable_tile : Tile
    {
        public Rectangle colision_region;
        public Collidable_tile(Sprite sprite) : base(sprite)
        {
 
        }
        public Collidable_tile(Sprite sprite, Rectangle colision_region) : base(sprite)
        {
            this.colision_region = colision_region;
        }
        public enum CollisionSide
        {
            None,
            Top,
            Bottom,
            Left,
            Right
        }
        public void draw_collision_region(Rectangle colision_region)
        {
            Globals.spriteBatch.Draw(sprite.texture, colision_region, sprite.region, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 0.6f);
        }
        public override Tile Clone()
        {
            return new Collidable_tile(sprite, colision_region);
        }
    }
}
