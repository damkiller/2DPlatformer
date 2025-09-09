using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleShooter.Engine.Textures;
using SimpleShooter.Engine.Tiles.FullyPreparedTiles;
using SimpleShooter.Engine.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static SimpleShooter.Engine.Collidable_tile;

namespace SimpleShooter.Engine.Characters
{
    public class Player
    {
        public Vector2 dim;
        public Vector2 pos;
        public Vector2 NextMove;
        public Rectangle player_zone;
        public Box<Vector2> shift;
        public Sprite sprite;

        private Vector2 collision_sprite_shift = new Vector2(20, 20);
        public Rectangle player_collision_box { get { return new Rectangle((int)(pos.X + collision_sprite_shift.X), (int)(pos.Y + collision_sprite_shift.Y), 28, 32); } }
        public Color color = Color.White;
        public SpriteEffects x_movement_flip = SpriteEffects.None;

        public Func<Player, List<(CollisionSide,float)>> Map_Collision;

        public PlayerStates player_actions;





        public Player(Vector2 dim, Vector2 pos, Box<Vector2> shift)
        {
            this.dim = dim;
            this.pos = pos;
            this.shift = shift;
            player_actions = new PlayerStates(this);

        }
        public void Update(KeyboardState keyboard, GameTime gameTime)
        {
            player_actions.Update(keyboard, gameTime);
            ScrollLogic(NextMove);


        }
        public void ScrollLogic(Vector2 next_move)
        {
            Vector2 new_pos = pos + next_move;

            if (player_zone.Contains(new_pos))
            {
                pos += next_move;
            }
            else
            {
                shift.value += next_move;
            }


        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(sprite.texture, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), sprite.region, color, 0, Vector2.Zero, x_movement_flip, 0.1f);
            //Globals.spriteBatch.Draw(LunarTileset.small_bush.texture, player_collision_box, sprite.region, Color.Red, 0, Vector2.Zero, x_movement_flip, 0.1F);
            //player_zone.Draw(Color.Red);
        }




    }
}
