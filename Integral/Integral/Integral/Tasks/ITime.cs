namespace Integral.Tasks
{
    public interface ITime
    {
        public static double MMTime()
        {
            DateTime start = DateTime.Now;
            var rand = new Random();

            Point point = new Point()
            {
                Xc = rand.NextDouble(),
                Yc = rand.NextDouble(),
                Zc = default
            };

            point.Zc = point.Xc * point.Xc * point.Yc * point.Yc;

            var required = DateTime.Now - start;
            return required.TotalMilliseconds/1000;
        }

        public static double GMTime()
        {
            DateTime start = DateTime.Now;
            var rand = new Random();
            int pointsInMyArea = default;

            Point point = new Point()
            {
                Xc = rand.NextDouble(),
                Yc = rand.NextDouble(),
                Zc = rand.NextDouble()
            };

            if (point.Zc <= point.Xc * point.Xc * point.Yc * point.Yc)
            {
                pointsInMyArea = pointsInMyArea + 1;
            }

            var required = DateTime.Now - start;
            return required.TotalMilliseconds/1000;
        }
    }
}
