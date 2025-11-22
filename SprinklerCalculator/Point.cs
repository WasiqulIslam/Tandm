using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Development startd by Wasiqul Islam on 20/11/2025

namespace SprinklerCalculator
{
    public class Point
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point(double x, double y, double z )
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point Add(Point a, Point b)
        {
            double x = a.X + b.X;
            double y = a.Y + b.Y;
            double z = a.Z + b.Z;
            return new Point(x, y, z);
        }

        public static Point Subtract(Point a, Point b)
        {
            double x = a.X - b.X;
            double y = a.Y - b.Y;
            double z = a.Z - b.Z;
            return new Point(x, y, z);
        }

        public static Point Multiply(Point v, double t)
        {
            return new Point ( v.X * t, v.Y * t, v.Z * t );
        }

        public static double CalculateDistance(Point a, Point b)
        {

            var part1 = 
                Math.Pow((b.X - a.X), 2) +
                Math.Pow((b.Y - a.Y), 2) +
                Math.Pow((b.Z - a.Z), 2);
            return Math.Sqrt(part1);

        }

        public static Point CrossProduct(Point a, Point b)
        {
            return new Point
            (
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X
            );
        }

        public static double DotProduct(Point a, Point b)
        {
            return a.X* b.X + a.Y * b.Y + a.Z * b.Z;
        }

        public static double Magnitude(Point v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public static Point GetDirectionVector(Point A, Point B, 
            double desiredLength) //desiredLength can be 2500
        {
            // Step 1: Compute vector
            Point vector = Point.Subtract(B, A);

            // Step 2: Compute magnitude
            double magnitude = Point.Magnitude(vector);

            if (magnitude == 0)
                throw new Exception("Points A and B are identical; direction vector undefined.");

            // Step 3: Normalize and scale
            double scale = desiredLength / magnitude;

            return Point.Multiply(vector, scale);
        }

    }

}

