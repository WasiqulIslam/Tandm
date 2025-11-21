using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Development startd by Wasiqul Islam on 20/11/2025

namespace SprinklerCalculator
{
    public class Pipe
    {

        public Pipe(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
