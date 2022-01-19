using MersenneTwister;

namespace Erlang
{
    class Program
    {
        static void Main()
        {
            float mu = default;
            float la = default;

            while (mu <= 0)
            {
                Console.WriteLine("Please, enter value of mu= ");
                mu = float.Parse(Console.ReadLine()); //2
            }

            while (la <= 0)
            {
                Console.WriteLine("Please, enter value of la= ");
                la = float.Parse(Console.ReadLine()); //1
            }

            Console.WriteLine("Please, enter number of iteration N= ");
            int N = int.Parse(Console.ReadLine());

            List<Point> points = new();
            var rand = MTRandom.Create();

            for (int i = 0; i < N; i++)
            {
                points.Add(new Point()
                {
                    X = Convert.ToSingle(rand.NextDouble() * rand.Next()),
                    Y = default
                });
            }

            foreach (Point point in points)
            {
                point.Y = Convert.ToSingle(mu * la * (Math.Exp(-mu * point.X) - Math.Exp(-la * point.Y)) / (la - mu));
            }

            List<Point> Upoints = new(N+1);
            
            for (int i = 1; i <= N; i++)
            {
                Upoints[i] = points[i - 1];
            }
            Upoints[0].X = 0;
            Upoints[0].Y = 0;
            Upoints[N+1].X = 1;
            Upoints[N+1].Y = 1;
            Upoints.Sort();

            float Sherman = 0;
            float alpha = 0.05f;

            for (int i = 1; i <= N ; i++)
            {
                Sherman = Sherman + Math.Abs(Upoints[i].X - Upoints[i-1].X - 1 / (N+1));
            }
            Sherman = Sherman / 2;

            //float ShermanN = Convert.ToSingle((Sherman - Math.Pow(N / (N + 1), N + 1)) / ((Math.Pow(2 * N, N + 2) + N * Math.Pow(N - 1, N + 2)) / (N + 2) * Math.Pow(N + 1, N + 2) - Math.Pow(N / (N + 1), 2 * N + 2)));
            
        }
    }
}