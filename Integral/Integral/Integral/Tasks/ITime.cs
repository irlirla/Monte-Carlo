namespace Integral.Tasks
{
    public interface ITime
    {
        public static double MMTime(int N)
        {
            DateTime start = DateTime.Now;
            var rand = new Random();
            List<Point> points = new();

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
            }

            var required = (DateTime.Now - start)/N;
            return required.TotalMilliseconds/1000;
        }

        public static double GMTime(int N)
        {
            DateTime start = DateTime.Now;
            var rand = new Random();
            List<Point> points = new();

            while (points.Count() != N)
            {
                double x = rand.NextDouble();
                double y = rand.NextDouble();
                double z = rand.NextDouble();

                if (x <= y)
                {
                    points.Add(new Point()
                    {
                        Xc = x,
                        Yc = y,
                        Zc = z
                    });
                }
            }

            var required = (DateTime.Now - start)/N;
            return required.TotalMilliseconds/1000;
        }
    }
}
