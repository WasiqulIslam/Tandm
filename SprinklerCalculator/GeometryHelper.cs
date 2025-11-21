//Development startd by Wasiqul Islam on 20/11/2025


namespace SprinklerCalculator
{
    public class GeometryHelper
    {

        private const double Tolerance = 1e-6; // Epsilon for plane distance check
        private const int MIN_DISTANCE = 500;

        //use only x and y values for 2D polygon check, z remains same for all points
        public bool IsPointInPolygonWithDistanceFromWalls(Point sprinklePoint, 
            List<Point> roomTopCornersWithSameHeight)
        {

            if( IsPointOutsideConvexPlanarQuad(sprinklePoint,
                roomTopCornersWithSameHeight[0],
                roomTopCornersWithSameHeight[1],
                roomTopCornersWithSameHeight[2],
                roomTopCornersWithSameHeight[3]))
            { 
                return false;
            }

            double distanceFromWall =
                CalculateDistance(sprinklePoint,
                    roomTopCornersWithSameHeight[0], roomTopCornersWithSameHeight[1]);
            if(distanceFromWall < MIN_DISTANCE)
            {
                return false;
            }

            distanceFromWall =
                CalculateDistance(sprinklePoint,
                    roomTopCornersWithSameHeight[1], roomTopCornersWithSameHeight[2]);
            if (distanceFromWall < MIN_DISTANCE)
            {
                return false;
            }

            distanceFromWall =
                CalculateDistance(sprinklePoint,
                    roomTopCornersWithSameHeight[2], roomTopCornersWithSameHeight[3]);
            if (distanceFromWall < MIN_DISTANCE)
            {
                return false;
            }

            distanceFromWall =
                CalculateDistance(sprinklePoint,
                    roomTopCornersWithSameHeight[3], roomTopCornersWithSameHeight[0]);
            if (distanceFromWall < MIN_DISTANCE)
            {
                return false;
            }

            return true;

        }

        private double CalculateDistance(Point sprinklePoint, Point a, Point b)
        {
            Point closestPoint = GetClosestPointOnLineSegment(a, b, sprinklePoint);
            double distance = Point.CalculateDistance(sprinklePoint, closestPoint);
            return distance;
        }

        private Point GetClosestPointOnLineSegment(Point a, Point b, Point p)
        {
            // 1. Vector from A to P
            Point ap = new Point ( p.X - a.X, p.Y - a.Y, a.Z );

            // 2. Vector from A to B (the line direction vector)
            Point ab = new Point ( b.X - a.X, b.Y - a.Y, a.Z );

            // Calculate squared length of AB vector: |AB|^2
            double magnitudeAB_Squared = ab.X * ab.X + ab.Y * ab.Y;

            // If A and B are the same point, return A
            if (magnitudeAB_Squared == 0)
            {
                return a;
            }

            // Calculate the dot product (AP . AB)
            double dotProduct = ap.X * ab.X + ap.Y * ab.Y;

            // 3. Calculate the parameter t
            double t = dotProduct / magnitudeAB_Squared;

            // Clamp t to the [0, 1] range for a line segment
            // t < 0: Closest point is A
            // t > 1: Closest point is B
            // 0 <= t <= 1: Closest point is on the segment
            t = Math.Clamp(t, 0f, 1f);

            // 4. Calculate the closest point C
            Point c = new Point
            (
                a.X + ab.X * t,
                a.Y + ab.Y * t,
                a.Z
            );

            return c;
        }

        public Point ProjectPointToPlane(Point p, Point a, Point b, Point c)
        {
            // 1. Find two vectors in the plane (e.g., AB and AC)
            Point vectorAB = Point.Subtract(b, a);
            Point vectorAC = Point.Subtract(c, a);

            // 2. Calculate the Normal Vector (n) using the Cross Product
            Point normal = Point.CrossProduct(vectorAB, vectorAC);

            // *Note: Using any three non-collinear points (like A, B, C) 
            // is sufficient to define the plane, regardless of the fourth point D.*

            // 3. Find the vector from a plane point (A) to the target point (p)
            Point vectorAP = Point.Subtract(p, a);

            // 4. Calculate the scalar factor 't' (the fraction in the main equation)
            // t = (n . (P - P0)) / (n . n)
            double numerator = Point.DotProduct(normal, vectorAP);
            double denominator = Point.DotProduct(normal, normal);

            // Avoid division by zero if the points are collinear (denominator is 0)
            if (denominator == 0)
            {
                // Should handle this case based on program's requirements, 
                // but for a valid plane, this should not happen.
                return p;
            }

            double t = numerator / denominator;

            // 5. Calculate the projection vector component (t * n)
            Point projectionVector = Point.Multiply(normal, t);

            // 6. Calculate the final projected point (P - (t * n))
            Point projectedPoint = Point.Subtract(p, projectionVector);

            return projectedPoint;
        }

        public Point GetNearestConnectionPoint(Point sprinklePoint, List<Pipe> pipes)
        {
            
            double minDistance = double.MaxValue;
            Point? selectedPoint = null;
            foreach(Pipe pipe in pipes)
            {
                Point closestPoint = GetClosestPointOnLineSegment(
                    pipe.StartPoint, 
                    pipe.EndPoint, 
                    sprinklePoint);
                double distance = Point.CalculateDistance(sprinklePoint, closestPoint);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    selectedPoint = closestPoint;
                }
            }

            if(selectedPoint == null)
            {
                throw new Exception("No connection point found.");
            }
            return selectedPoint;

        }

        // Determines if a point Q is outside the planar, convex polygon defined by P1, P2, P3, P4
        public bool IsPointOutsideConvexPlanarQuad(Point point, 
            Point c1, Point c2, Point c3, Point c4)
        {
            // 1. Calculate the plane's normal vector N
            // We use P1, P2, P3 to define the plane.
            Point v12 = Point.Subtract(c2, c1);
            Point v13 = Point.Subtract(c3, c1);
            Point N = Point.CrossProduct(v12, v13);

            // Check for degenerate polygon (points are collinear/coplanar and N is zero)
            if (Point.Magnitude(N) < Tolerance)
            {
                // The points are nearly collinear, not a true plane. 
                // In a real application, you'd need a robust 2D projection/bounding box check here.
                // For this simplified case, we return true (outside) as the polygon is degenerate.
                return true;
            }

            // 2. Check if Q is on the plane defined by P1, N.
            // The plane equation is N . (P - P1) = 0
            // Distance is |N . (Q - P1)| / |N|
            Point v1Q = Point.Subtract(point, c1);
            double distanceToPlane = Math.Abs(Point.DotProduct(N, v1Q)) / Point.Magnitude(N);

            // If the point is too far from the plane, it is outside
            if (distanceToPlane > Tolerance)
            {
                return true;
            }

            // 3. Check if Q is inside the 2D projection using the **Same Side** method.
            // This only works for a convex polygon.
            // It tests if Q is on the same side of every edge (P_i, P_{i+1}) relative to the polygon's normal.

            // Define the polygon edges in order: (P1,P2), (P2,P3), (P3,P4), (P4,P1)
            Point[] vertices = { c1, c2, c3, c4 };

            // Check for each edge E_i = (P_i, P_{i+1})
            for (int i = 0; i < 4; i++)
            {
                Point P_start = vertices[i];
                Point P_end = vertices[(i + 1) % 4];

                // Edge vector E = P_end - P_start
                Point E = Point.Subtract(P_end, P_start);

                // Vector from edge start to Q: v_startQ = Q - P_start
                Point v_startQ = Point.Subtract(point, P_start);

                // Calculate the cross product (E x v_startQ)
                // The resulting vector is normal to the plane defined by E and v_startQ.
                // Its direction indicates which side of the edge E the point Q lies.
                Point testNormal = Point.CrossProduct(E, v_startQ);

                // Check the projection of the test normal onto the polygon's normal N.
                // If Q is outside, the projection will have an opposite sign (or be zero).
                double dot = Point.DotProduct(N, testNormal);

                // If the dot product is negative (Q is on the "wrong side" of the edge) 
                // AND it's significantly non-zero (not within the tolerance of being on the edge), 
                // the point is outside.
                if (dot < -Tolerance)
                {
                    return true; // Outside
                }
            }

            // If it passed both the plane check and the 2D boundary check, it's inside.
            return false; // Inside
        }

    }
}
