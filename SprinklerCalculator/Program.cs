using System;

//Development startd by Wasiqul Islam on 20/11/2025

namespace SprinklerCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var sprinklerGenerator = new SprinklerGenerator(
                roomCorners: new List<Point>
                {
                    new Point(97500.01,34000.00,2500.00),
                    new Point(85647.67,43193.61,2500.00),
                    new Point(91776.75,51095.16, 2530.00),
                    new Point(103629.07,41901.55, 2530.00)
                },
                pipes: new List<Pipe>
                {
                    new Pipe(
                        new Point(98242.11,36588.29,3000.00), 
                        new Point(87970.10,44556.09,3500.00)
                        ),
                    new Pipe(
                        new Point(99774.38,38563.68,3500.00), 
                        new Point(89502.37,46531.47,3000.00)
                        ),
                    new Pipe(
                        new Point(101306.65,40539.07,3000.00), 
                        new Point(91034.63,48507.01,3000.00)
                        )
                }
            );
            sprinklerGenerator.GenerateSprinklers();

            Console.ReadKey();

        }
    }
}