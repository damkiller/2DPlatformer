using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Textures
{
    public class textures
    {
        public LunarTileset tileset;
        public TexturesPlayer texturesPlayer;
        public MonsterTextures monsterTextures;
        public textures()
        {
            tileset = new LunarTileset();
            texturesPlayer = new TexturesPlayer();
            monsterTextures = new MonsterTextures();

        }


    }
}
