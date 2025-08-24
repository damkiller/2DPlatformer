using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine
{
    public class Tile
    {
        public Sprite sprite;

        public Tile(Sprite sprite)
        {
            this.sprite = sprite;
        }
        public void Draw(Vector2 pos, Vector2 dim)
        {
            Globals.spriteBatch.Draw(sprite.texture, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), sprite.region, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
        }
        public virtual Tile Clone()
        {
            return new Tile(sprite);
        }
    }
}
