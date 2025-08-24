using Microsoft.Xna.Framework;
using SimpleShooter.Engine.Tiles.FullyPreparedTiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Utilities
{
    public static class DrawRectangles
    {
        public static void Draw(this Rectangle rectangle, Color color)
        {
            Globals.spriteBatch.Draw(TestTile.collision_rectangle.texture, rectangle, color);
        }


    }
}
