using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SimpleShooter.Engine.Textures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace SimpleShooter.Engine
{
    public struct Sprite
    {
        public string name;
        public Rectangle region;
        public Texture2D texture;

        public Sprite(string name, Rectangle region, Texture2D texture)
        {
            this.name = name;
            this.texture = texture;
            this.region = region;
        }
        public Sprite(string name, Texture2D texture)
        {
            this.name = name;
            this.texture = texture;
        }
        public void Draw(Vector2 dim, Vector2 pos)
        {
            Globals.spriteBatch.Draw(texture, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), region, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
    public struct AnimatedSprite
    {
        
    }
}
