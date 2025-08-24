using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Textures
{
    public class TexturesPlayer
    {
        public static Sprite base_sprite;

        public TexturesPlayer()
        {
            base_sprite = new Sprite("Characters/DarkSamurai", new Rectangle(0,0,64,64), Globals.Content.Load<Texture2D>("Characters/DarkSamurai"));

        }


    }
}
