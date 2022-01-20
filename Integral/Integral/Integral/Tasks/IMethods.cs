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
                double f = rand.NextDouble();

                if (x <= y && y <= z)
                {
                    points.Add(new Point()
                    {
                        Xc = x,
                        Yc = y,
                        Zc = z,
                        Fc = f
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
                if (point.Fc <= point.Xc * point.Xc * point.Yc * point.Yc)
                {
                    pointsInMyArea = pointsInMyArea + 1;
                }
            }

            double integral = Convert.ToDouble(pointsInMyArea / (6*points.Count()));
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
                double z = rand.NextDouble();

                if (x <= y && y <= z)
                {
                    points.Add(new Point()
                    {
                        Xc = x,
                        Yc = y,
                        Zc = z,
                        Fc = default
                    });
                }
            }

            foreach (Point x in points)
            {
                x.Fc = x.Xc * x.Xc * x.Yc * x.Yc;

                fsum = fsum + Convert.ToDecimal(x.Fc);
            }

            foreach (Point x in points)
            {
                x.Fc = x.Xc * x.Xc * x.Xc * x.Xc * x.Yc * x.Yc * x.Yc * x.Yc;

                f2sum = f2sum + Convert.ToDecimal(x.Fc);
            }

            decimal result = fsum / (6*N);
            decimal Dispersion = f2sum / (6*N) - result * result;
            return (Convert.ToDouble(result), Convert.ToDouble(Dispersion));
        }
    }
}
