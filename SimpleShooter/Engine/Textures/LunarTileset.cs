using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Textures
{
    public class LunarTileset
    {
        private static Texture2D texture;
        private Rectangle new_region = new Rectangle(0,0,32,32);

        public static Sprite left_roof_corner { get; private set; }
        public static Sprite roof { get; private set; }
        public static Sprite broken_roof { get; private set; }
        public static Sprite broken_roof_2 { get; private set; }
        public static Sprite top_roof_corner { get; private set; }
        public static Sprite one_cloud { get; private set; }
        public static Sprite two_clouds { get; private set; }
        public static Sprite small_bush { get; private set; }
        public static Sprite medium_bush { get; private set; }
        public static Sprite large_bush { get; private set; }
        public static Sprite left_side_wall { get; private set; }
        public static Sprite right_side_wall { get; private set; }
        public static Sprite broken_left_side_wall { get; private set; }
        public static Sprite broken_right_side_wall { get; private set; }
        public static Sprite left_side_no_roof_cloud { get; private set; }
        public static Sprite no_roof_cloud { get; private set; }
        public static Sprite right_side_no_roof_cloud { get; private set; }
        public static Sprite left_side_ground_cloud { get; private set; }
        public static Sprite ground_cloud { get; private set; }
        public static Sprite right_side_ground_cloud { get; private set; }
        public static Sprite broken_island { get; private set; }
        public static Sprite island { get; private set; }


        public LunarTileset()
        {
            int move_region_x = 32, move_region_y = 32;
            texture = Globals.Content.Load<Texture2D>("Tileset/lunar");

            left_roof_corner = new Sprite("LunarTileset/left_roof_corner", new_region, texture);
            new_region.X += move_region_x;

            roof = new Sprite("LunarTileset/roof", new_region, texture);
            new_region.X += move_region_x;

            broken_roof = new Sprite("LunarTileset/broken_roof", new_region, texture);
            new_region.X += move_region_x;

            broken_roof_2 = new Sprite("LunarTileset/broken_roof_2", new_region, texture);
            new_region.X += move_region_x;

            top_roof_corner = new Sprite("LunarTileset/top_roof_corner", new_region, texture);
            new_region.X += move_region_x;

            one_cloud = new Sprite("LunarTileset/one_cloud", new_region, texture);
            new_region.X += move_region_x;

            two_clouds = new Sprite("LunarTileset/two_clouds", new_region, texture);
            new_region.X += move_region_x;

            small_bush = new Sprite("LunarTileset/small_bush", new_region, texture);
            new_region.X += move_region_x;

            medium_bush = new Sprite("LunarTileset/medium_bush", new_region, texture);
            new_region.X += move_region_x;

            large_bush = new Sprite("LunarTileset/large_bush", new_region, texture);

            new_region.X = 0;
            new_region.Y += move_region_y;

            left_side_wall = new Sprite("LunarTileset/left_side_wall", new_region, texture);
            new_region.X += move_region_x;

            right_side_wall = new Sprite("LunarTileset/right_side_wall", new_region, texture);
            new_region.X += move_region_x;

            broken_left_side_wall = new Sprite("LunarTileset/broken_left_side_wall", new_region, texture);
            new_region.X += move_region_x;

            broken_right_side_wall = new Sprite("LunarTileset/broken_right_side_wall", new_region, texture);
            new_region.X += move_region_x;

            left_side_no_roof_cloud = new Sprite("LunarTileset/right_side_cloud", new_region, texture);
            new_region.X += move_region_x;

            no_roof_cloud = new Sprite("LunarTileset/right_side_cloud", new_region, texture);
            new_region.X += move_region_x;

            right_side_no_roof_cloud = new Sprite("LunarTileset/right_side_no_roof_cloud", new_region, texture);

            new_region.X = 0;
            new_region.Y += move_region_y;

            left_side_ground_cloud = new Sprite("LunarTileset/left_side_ground_cloud", new_region, texture);

            new_region.X += move_region_x;

            ground_cloud = new Sprite("LunarTileset/ground_cloud", new_region, texture);

            new_region.X += move_region_x;

            right_side_ground_cloud = new Sprite("LunarTileset/right_side_ground_cloud", new_region, texture);

            new_region.X += move_region_x;

            broken_island = new Sprite("LunarTileset/broken_island", new_region, texture);

            new_region.X += move_region_x;

            island = new Sprite("LunarTileset/island", new_region, texture);
        }
        public void InitializeNewSprite(ref Sprite sprite, string name, Rectangle new_region)
        {
            sprite = new Sprite(name, new_region, texture);
        }












    }
}
