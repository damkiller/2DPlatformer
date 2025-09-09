using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D11;
using SimpleShooter.Engine.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleShooter.Engine.Collidable_tile;

namespace SimpleShooter.Engine.Characters
{
    public class PlayerStates
    {
        public Player player;
        private ActiveState jump;
        private ActiveState falling;

        public float speed = 1;
        public float max_speed = 5;
        public float falling_speed = 1;
        public float max_falling_speed = 5;
        public float speed_acceleration = 4f;
        public float Line_for_death_of_Fall = 600f;


        public Polynomial jump_acceration;
        public Polynomial falling_acceration;
        public Acceration acceration;

        HashSet<CollisionSide> prev_collisions = new HashSet<CollisionSide>();

        public bool is_d_key_pressed;

        public PlayerStates(Player player)
        {
            this.player = player;
            jump = new ActiveState(JumpUpdate);
            falling = new ActiveState(FallingUpdate);
            falling_acceration = new Polynomial(new List<float> { 1f, 2 });
            jump_acceration = new Polynomial(new List<float> { -0.5f, 12 });
            acceration = new Acceration(2, 8, 4f);
        }

        public void Update(KeyboardState keyboard, GameTime gameTime)
        {
            player.NextMove = new Vector2(0, 0);
            falling.Activate();
            if (keyboard.IsKeyDown(Keys.D))
            {
                player.NextMove.X += acceration.currect_speed;
                player.x_movement_flip = SpriteEffects.None;
                if (!is_d_key_pressed)
                {
                    acceration.Reset();
                }
                is_d_key_pressed = true;
                acceration.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                player.NextMove.X -= acceration.currect_speed;
                player.x_movement_flip = SpriteEffects.FlipHorizontally;
                if (is_d_key_pressed)
                {
                    acceration.Reset();
                }
                is_d_key_pressed = false;
                acceration.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (keyboard.IsKeyDown(Keys.Space) && !jump.is_active && prev_collisions.Contains(CollisionSide.Bottom))
            {
                jump.Activate();
            }
            jump.Update();
            falling.Update();

            prev_collisions = new();
            if (player.NextMove != Vector2.Zero)
            {
                foreach ((CollisionSide, float) item in player.Map_Collision(player))
                {
                    switch (item.Item1)
                    {
                        case CollisionSide.Left:
                            player.NextMove.X = item.Item2;
                            prev_collisions.Add(CollisionSide.Left);
                            break;
                        case CollisionSide.Right:
                            player.NextMove.X = item.Item2;
                            prev_collisions.Add(CollisionSide.Right);
                            break;
                        case CollisionSide.Top:
                            player.NextMove.Y = item.Item2;
                            prev_collisions.Add(CollisionSide.Top);
                            break;
                        case CollisionSide.Bottom:
                            player.NextMove.Y = item.Item2;
                            prev_collisions.Add(CollisionSide.Bottom);
                            break;
                    }
                }
            }
        }
        public bool JumpUpdate(int time)
        {
            float d = jump_acceration.Evaluate(time);
            if (d > 0)
            {
                player.NextMove.Y -= d;
            }
            return d > 0;
        }
        public bool FallingUpdate(int time)
        {
            float e = falling_acceration.Evaluate(time);
            if (jump.is_active)
            {
                return true;
            }
            if (e < max_falling_speed)
            {
                player.NextMove.Y += max_falling_speed;
                if(Line_for_death_of_Fall < player.pos.Y + player.shift.value.Y)
                {
                    FallDeath();
                }
            }
            else
            {
                player.NextMove.Y += e;
            }
            return prev_collisions.Contains(CollisionSide.Bottom);
        }

        public void FallDeath()
        {
            player.shift.value = Vector2.Zero;
            player.pos = player.player_zone.Center.ToVector2();


        }


    }
    public struct Acceration
    {
        public float starting_speed;
        public float currect_speed { get; private set; }
        public float max_speed;

        public float speed_acceleration;
        public Acceration(float starting_speed, float max_speed, float speed_acceleration)
        {
            this.starting_speed = starting_speed;
            this.max_speed = max_speed;
            this.speed_acceleration = speed_acceleration;
        }

        public void Update(float delta_time)
        {
            currect_speed += starting_speed * speed_acceleration * delta_time;
            if (currect_speed > max_speed)
            {
                currect_speed = max_speed;
            }
        }
        public void Reset()
        {
           currect_speed = starting_speed;
        }
    }






    
}

