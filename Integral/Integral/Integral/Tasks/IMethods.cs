namespace Integral
{
    public interface IMethods
    {
        public static List<Point> ThrowPoints(int N)
        {
            List<Point> points = new();
            var rand = new Random();

            while (points.Count() != N)
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();
                double z = rand.NextDouble();

                if (x <= y && y <= z)
                {
                    points.Add(new Point()
                    {
                        Xc = x,
                        Yc = y,
                        Zc = z
                    });
                }
            }
            return points;
        }

        public static double GeometricMethod(List<Point> points)
        {
            double pointsInMyArea = new();

            foreach (Point point in points)
            {
                if (point.Zc <=  )
                {
                    pointsInMyArea = pointsInMyArea + 1;
                }
            }

            double integral = Convert.ToDouble(pointsInMyArea / points.Count());
            return integral;
        }

        public static (double, double) MeanMethod(int N)
        {
            decimal fsum = 0;
            decimal f2sum = 0;
            List<Point> points = new();
            var rand = new Random();

            while (points.Count() != N)
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();

                if (x <= y)
                {
                    points.Add(new Point()
                    {
                        Xc = x,
                        Yc = y,
                        Zc = default
                    });
                }
            }

            foreach (Point x in points)
            {
                x.Zc = x.Xc * x.Xc * x.Yc * x.Yc;

                fsum = fsum + Convert.ToDecimal(x.Zc);
            }

            foreach (Point x in points)
            {
                x.Zc = x.Xc * x.Xc * x.Xc * x.Xc * x.Yc * x.Yc * x.Yc * x.Yc;

                f2sum = f2sum + Convert.ToDecimal(x.Zc);
            }

            decimal result = fsum / N;
            decimal Dispersion = f2sum / N - result * result;
            return (Convert.ToDouble(result), Convert.ToDouble(Dispersion));
        }
    }
}
