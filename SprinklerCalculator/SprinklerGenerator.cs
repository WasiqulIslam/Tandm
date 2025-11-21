using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Development startd by Wasiqul Islam on 20/11/2025

namespace SprinklerCalculator
{
    public class SprinklerGenerator
    {

        private readonly List<Point> _roomTopCorners;
        private readonly List<Pipe> _pipes;

        //room corners are provided in clockwise order
        public SprinklerGenerator(List<Point> roomCorners,
            List<Pipe> pipes
            ) {
            _roomTopCorners = roomCorners;
            _pipes = pipes;
        }

        public void GenerateSprinklers()
        {

            Validate();

            //take the lower z value of the room top corners as the ceiling height
            double ceilingHeight = _roomTopCorners.Min(corner => corner.Z);

            List<Point> possibleSprinkleGrid = new List<Point>();
            CalculatePossibleSprinkleGrid(ceilingHeight, possibleSprinkleGrid);

            List<Point> roomTopCornersWithSameHeight = new List<Point>();
            foreach (Point p in _roomTopCorners)
            {
                roomTopCornersWithSameHeight.Add(new Point(p.X, p.Y, ceilingHeight));
            }

            //filter possible sprinkle points that are inside the room polygon
            //and at a minimun distance (2500mm) from walls
            List<Point> selectedSprinklePointsWithSameHeight = new List<Point>();
            FilterSprinklePointsAndIncludeRequiredPoints(possibleSprinkleGrid, roomTopCornersWithSameHeight, selectedSprinklePointsWithSameHeight);

            //project points to the roof level plane
            List<Point> finalSprinklePoints = new List<Point>();
            ProjectPointsToTheRoofPlane(_roomTopCorners, 
                selectedSprinklePointsWithSameHeight, finalSprinklePoints);

            //find nearest pipe connection points for each sprinkle point
            List<Point> nearestConnectionPoints = new List<Point>();
            GeometryHelper geometryHelper = new GeometryHelper();
            foreach (Point sprinklePoint in finalSprinklePoints)
            {
                Point connectionPoint = geometryHelper
                    .GetNearestConnectionPoint(sprinklePoint,_pipes);
                nearestConnectionPoints.Add(connectionPoint);
            }

            Console.WriteLine("Total sprinkle points: " + finalSprinklePoints.Count);
            for (int i = 0; i < finalSprinklePoints.Count; i++)
            {
                Console.WriteLine("---------------------------");
                Point p = finalSprinklePoints[i];
                Console
                    .WriteLine($"Sprinkler Point at X: {p.X}, Y: {p.Y}, Z: {p.Z}");
                p = nearestConnectionPoints[i];
                Console
                    .WriteLine($"Nearest pipe connection point at X: {p.X}, Y: {p.Y}, Z: {p.Z}");
            }

        }

        private void ProjectPointsToTheRoofPlane(List<Point> roomTopCornersWithSameHeight, List<Point> selectedSprinklePointsWithSameHeight, List<Point> finalSprinklePoints)
        {
            GeometryHelper geometryHelper = new GeometryHelper();
            foreach (Point point in selectedSprinklePointsWithSameHeight)
            {
                Point projectedPoint = geometryHelper
                    .ProjectPointToPlane(
                        point,
                        roomTopCornersWithSameHeight[0],
                        roomTopCornersWithSameHeight[1],
                        roomTopCornersWithSameHeight[2]);
                finalSprinklePoints.Add(projectedPoint);
            }
        }

        private void FilterSprinklePointsAndIncludeRequiredPoints(List<Point> possibleSprinkleGrid, List<Point> roomTopCornersWithSameHeight, List<Point> selectedSprinklePointsWithSameHeight)
        {
            GeometryHelper helper = new GeometryHelper();
            foreach (Point sprinklePoint in possibleSprinkleGrid)
            {
                if (helper.IsPointInPolygonWithDistanceFromWalls(
                    sprinklePoint,
                    roomTopCornersWithSameHeight))
                {
                    selectedSprinklePointsWithSameHeight.Add(sprinklePoint);
                }
            }
        }

        private void CalculatePossibleSprinkleGrid(double ceilingHeight, List<Point> possibleSparkelGrid)
        {
            double minX = _roomTopCorners.Min(corner => corner.X);
            double maxX = _roomTopCorners.Max(corner => corner.X);
            double minY = _roomTopCorners.Min(corner => corner.Y);
            double maxY = _roomTopCorners.Max(corner => corner.Y);
            for (double x = minX; x <= maxX; x += 2500) //2500 mm grid
            {
                for (double y = minY; y <= maxY; y += 2500)
                {
                    possibleSparkelGrid.Add(new Point(x, y, ceilingHeight));
                }
            }
        }

        private void Validate()
        {
            if (_roomTopCorners == null || _roomTopCorners.Count != 4)
            {
                throw new ArgumentException("Room top corners must be defined by exactly 4 corners.");
            }

            if (_pipes == null || _pipes.Count == 0)
            {
                throw new ArgumentException("At least one pipe must be defined.");
            }
        }

    }
}
