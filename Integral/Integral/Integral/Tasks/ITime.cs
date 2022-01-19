namespace Integral.Tasks
{
    public interface ITime
    {
        public static double MMTime(int N)
        {
            DateTime start = DateTime.Now;
            var rand = new Random();
            List<Point> points = new();

            for (int i = 0; i < N; i++)
            {
                points.Add(new Point()
                {
                    Xc = rand.NextDouble(),
                    Yc = rand.NextDouble(),
                    Zc = default
                });
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

            for (int i = 0; i < N; i++)
            {
                points.Add(new Point()
                {
                    Xc = rand.NextDouble(),
                    Yc = rand.NextDouble(),
                    Zc = rand.NextDouble()
                });
            }

            var required = (DateTime.Now - start)/N;
            return required.TotalMilliseconds/1000;
        }
    }
}
