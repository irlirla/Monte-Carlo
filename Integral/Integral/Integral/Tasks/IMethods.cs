namespace Integral
{
    public interface IMethods
    {
        public static List<Point> ThrowPoints(int N)
        {
            List<Point> points = new();
            var rand = new Random();

            for (int i = 0; i < N; i++)
            {
                points.Add(new Point()
                {
                    Xc = rand.NextDouble(),
                    Yc = rand.NextDouble(),
                    Zc = rand.NextDouble()
                });
            }

            return points;
        }

        public static double GeometricMethod(List<Point> points)
        {
            double pointsInMyArea = new();

            foreach (Point point in points)
            {
                if (point.Zc <= point.Xc * point.Xc * point.Yc * point.Yc)
                {
                    pointsInMyArea = pointsInMyArea + 1;
                }
            }

            double integral = Convert.ToDouble(pointsInMyArea / points.Count);
            return integral;
        }

        public static (double, double) MeanMethod(int N)
        {
            decimal fsum = 0;
            decimal f2sum = 0;
            List<Point> points = new();
            var rand = new Random();

            for (int i = 0; i < N; i++)
            {
                points.Add(new Point() {
                    Xc = rand.NextDouble(),
                    Yc = rand.NextDouble(),
                    Zc = default
                });
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
