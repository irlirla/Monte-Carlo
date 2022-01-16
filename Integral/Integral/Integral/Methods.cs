namespace Integral
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    public class Methods
    {
        public static Point[] ThrowPoints(int N)
        {
            Point[] points = new Point[N];
            var rand = new Random();

            foreach (Point point in points)
            {
                point.X = rand.NextDouble();
                point.Y = rand.NextDouble();
                point.Z = rand.NextDouble();
            }

            return points;
        }

        public static double GeometricMethod(Point[] points)
        {
            int pointsInMyArea = new();

            foreach (var point in points)
            {
                if (point.X*point.X <= 1 &&
                    point.Y*point.Y <= 1)
                {
                    pointsInMyArea += pointsInMyArea;
                }
            }

            Console.WriteLine("The proportion of points got in the area: ", pointsInMyArea/points.Length);
            double integral = 1*pointsInMyArea / points.Length;

            return integral;
        }

        public static double MeanMethod(int N)
        {
            double fsum = 0;
            Point[] points = new Point[N];
            var rand = new Random();

            for (int i = 0; i < N; i++)
            {
                points[i].X = rand.NextDouble();
                points[i].Y = rand.NextDouble();

                points[i].Z = points[i].X * points[i].X * points[i].Y * points[i].Y;
                fsum = fsum + points[i].Z;
            }

            double result = fsum / N;
            return result;
        }

        //public static double Efficienty()
        //{

        //}
    }
}
