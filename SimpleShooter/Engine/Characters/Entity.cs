using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleShooter.Engine.Collidable_tile;

namespace SimpleShooter.Engine.Characters
{
    public abstract class Entity
    {
        public Vector2 pos;
        public Vector2 dim; //sprite dimentions
        public Vector2 NextMove;
        public Point collsion_box_size;
        public Rectangle collsion_box => new Rectangle((int)pos.X, (int)pos.Y, collsion_box_size.X, collsion_box_size.Y);
        public Func<Entity, List<(CollisionSide, float)>> Map_Collision;
        public Entity(Vector2 pos, Vector2 dim, Point collsion_box_size = default)
        {
            this.pos = pos;
            this.dim = dim;
            if (collsion_box_size == default)
            {
                this.collsion_box_size = new Point((int)dim.X, (int)dim.Y);
            }
            else
            {
               this.collsion_box_size = collsion_box_size;
            }
        }
        }
        

    }
