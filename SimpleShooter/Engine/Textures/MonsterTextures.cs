using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Textures
{
    public class MonsterTextures
    {
        public MonsterTextures()
        {
        }
        public static string texture_name = "monsters/monochrome_32x32";
        private static int size = 32;
        public static Sprite mage => new Sprite(texture_name + "/mage", new Rectangle(2 * size, 7 * size,size,size), Globals.Content.Load<Texture2D>(texture_name));
        public static Sprite crazy_mage => new Sprite(texture_name + "/crazy_mage", new Rectangle(3 * size, 7 * size, size, size), Globals.Content.Load<Texture2D>(texture_name));
        public static Sprite hornet => new Sprite(texture_name + "/hornet", new Rectangle(2 * size, 5 * size, size, size), Globals.Content.Load<Texture2D>(texture_name));
        public static Sprite moon => new Sprite(texture_name + "/moon", new Rectangle(6 * size, 6 * size, size, size), Globals.Content.Load<Texture2D>(texture_name));

        public static Sprite dragon => new Sprite(texture_name + "/dragon", new Rectangle(5 * size, 7 * size, size, size), Globals.Content.Load<Texture2D>(texture_name));


    }
}
