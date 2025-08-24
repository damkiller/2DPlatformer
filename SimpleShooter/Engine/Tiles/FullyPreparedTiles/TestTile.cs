using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleShooter.Engine.Tiles.FullyPreparedTiles
{
    public static class TestTile
    {
        public static Sprite collision_rectangle => new("Tests/tile_test", Globals.Content.Load<Texture2D>("Tests/tile_test"));

        //AttributeTargets get("Tests/tile_test", Globals.Content.Load<Texture2D>("Tests/tile_test")); SetDataOptions

    }
}
