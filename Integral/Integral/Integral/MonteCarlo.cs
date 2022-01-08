namespace Integral
{
    public class MonteCarlo
    {
        public static double[,] RandomPointsInMyArea(int N)
        {
            double[,] points = new double[N, 3];
            double[,] pointsInMyArea = new double[,] { };
            int j = 0;
            var rand = new Random();
            int xmax = 1;
            int xmin = 0;
            int ymax = 1;
            int ymin = 0;
            int zmax = 1;
            int zmin = 0;

            for (int i=0; i <= N; i++)
            {
                points[i, 0] = rand.NextDouble();
                points[i, 1] = rand.NextDouble();
                points[i, 2] = rand.NextDouble();
            }

            for (int i=0; i<=N; i++)
            {
                if ((0 <= points[i,0]) && (points[i, 0] <= 1)
                    && (0 <= points[i, 1]) && (points[i, 1] <= 1)
                    && (0 <= points[i, 2]) && (points[i, 2] <= 1))
                {
                    pointsInMyArea[j, 0] = points[i, 0];
                    j += j;
                }
            }

            Console.WriteLine("The proportion of points got in the area: ", pointsInMyArea.Length/points.Length);

            return pointsInMyArea;
        }

        public static double MonteCarloMethod(double[,] points)
        {
            double result = new();

            

            return result;
        }
    }
}
