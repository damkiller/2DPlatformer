using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShooter.Engine.Utilities
{
    public static class MapFunctionality
    {
        public static void CreateShape<shape>(this Map map, Tile tile, shape some_shape, Point pos) where shape : Shape
        {
            foreach (Point e in some_shape.GetPoints())
            {
                map[pos.X + e.X, pos.Y + e.Y] = tile.Clone();
            }

        }
        public abstract class Shape
        {
            internal Point box_size;
            public abstract List<Point> GetPoints();
            public Shape(Point box_size)
            {
                this.box_size = box_size;
            }
        }
        public class Diamond : Shape
        {
            public Diamond(Point circle_space_occupied, int charge) : base(circle_space_occupied)
            {

            }
            public override List<Point> GetPoints()
            {
                int size = Math.Max(box_size.X, box_size.Y);
                int r = size % 2;
                int base_lenght = 1;
                int center = size / 2 + r;
                int sides_lenght_increase = 0;
                int change_of_size = 16;
                List<Point> points = new List<Point>();

                char[,] array2d = new char[size, size];

                int increasor = change_of_size;

                int j = 0;

                while (sides_lenght_increase * 2 - base_lenght + 2 >= 0)
                {

                    if (center - sides_lenght_increase - base_lenght > 0 && center + base_lenght + sides_lenght_increase < size)
                    {
                        for (int i = center - sides_lenght_increase; center + base_lenght + sides_lenght_increase > i; i++)
                        {
                            points.Add(new Point(j, i));
                        }
                    }
                    else
                    {
                        increasor = -change_of_size;
                        sides_lenght_increase += increasor;
                        continue;
                    }
                    j++;
                    sides_lenght_increase += increasor;
                }
                return points;
            }
        }
        public class Circle : Shape
        {
            public Circle(Point circle_space_occupied) : base(circle_space_occupied)
            {

            }
            public override List<Point> GetPoints()
            {
                int radius = int.Min(box_size.X, box_size.Y);
                Point center = new Point(0, 0);

                List<Point> points = new List<Point>();
                int radiusSquared = radius * radius;

                for (int y = -radius; y <= radius; y++)
                {
                    int x = (int)Math.Sqrt(radiusSquared - y * y);
                    for (int dx = -x; dx <= x; dx++)
                    {
                        points.Add(new Point(center.X + dx, center.Y + y));
                    }
                }

                return points;
            }
        }
    }



}
