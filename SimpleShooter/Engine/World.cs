using SimpleShooter.Engine.Characters;
using SimpleShooter.Engine.Textures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using SimpleShooter.Engine;
using System.Runtime.Intrinsics;
using SimpleShooter.Engine.Utilities;
using static SimpleShooter.Engine.Utilities.MapFunctionality;
using Microsoft.Xna.Framework.Input;

namespace SimpleShooter.Engine
{
    public class Box<T>(T value)
    {
        public T value = value;
    }

    public class World
    {
        public Map map;
        public Player player;
        public Box<Vector2> playerpos;
        public Box<Vector2> screensize;

        public World()
        {
            playerpos = new Box<Vector2>(new Vector2(0, 0));
            map = new Map(playerpos);
            player = new Player(new Vector2(64, 64), new Vector2(100, 100), playerpos);
            player.sprite = TexturesPlayer.base_sprite;
            map[5, 2] = new Tile(LunarTileset.island);
            map[3, 10] = new Collidable_tile(LunarTileset.island);
            map[2, 10] = new Collidable_tile(LunarTileset.island);
            map[1, 10] = new Collidable_tile(LunarTileset.island);
            map[4, 10] = new Collidable_tile(LunarTileset.island);
            map[4, 9] = new Collidable_tile(LunarTileset.island);
            map[5, 9] = new Collidable_tile(LunarTileset.island);
            map[6, 9] = new Collidable_tile(LunarTileset.island);
            map[7, 9] = new Collidable_tile(LunarTileset.island);
            map.CreateShape(new Collidable_tile(LunarTileset.island), new Circle(new Microsoft.Xna.Framework.Point(8, 8)), new Microsoft.Xna.Framework.Point(20, 15));


            

            player.Map_Collision = new(map.CheckCollision);

        }
        public void Initialize()
        {
            player.player_zone = new Microsoft.Xna.Framework.Rectangle((int)(screensize.value.X / 4), (int)(screensize.value.Y / 4), (int)screensize.value.X/2, (int)screensize.value.Y/2);
            player.pos = new Vector2((int)(screensize.value.X / 4), (int)(screensize.value.Y / 4));
        }
        public void Draw()
        {
           player.Draw();
           map.Draw();
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState KeyboardInput = Keyboard.GetState();
            player.Update(KeyboardInput, gameTime);
        }
    }

}
