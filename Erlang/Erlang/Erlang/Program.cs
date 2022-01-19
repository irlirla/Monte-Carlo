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
                Console.Write("Please, enter value of mu= ");
                mu = float.Parse(Console.ReadLine()); //2
            }

            while (la <= 0)
            {
                Console.Write("Please, enter value of la= ");
                la = float.Parse(Console.ReadLine()); //1
            }

            Console.Write("Please, enter number of iteration N= ");
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

            List<Point> Upoints = new();

            for (int i = 0; i <= N + 1; i++)
            {
                Upoints.Add(new Point());
            }
            
            for (int i = 1; i <= N; i++)
            {
                Upoints[i].X = points[i - 1].X;
                Upoints[i].Y = points[i - 1].Y;
            }
            Upoints[0].X = 0.0f;
            Upoints[0].Y = 0.0f;
            Upoints[N+1].X = 1.0f;
            Upoints[N+1].Y = 1.0f;
            Upoints.OrderBy(x => x.X);

            float Sherman = 0;
            Console.Write("Please, enter value of alpha= "); //0.05f
            float alpha = float.Parse(Console.ReadLine());

            for (int i = 1; i <= N ; i++)
            {
                Sherman = Sherman + Math.Abs(Upoints[i].X - Upoints[i-1].X - 1 / (N+1));
            }
            Sherman = Sherman / 2;

            Console.Write($"Please, enter the critical value of Sherman statistics at 1-a={1 - alpha} and N={N}: ");
            float ShermanC = float.Parse(Console.ReadLine());

            if (Sherman < ShermanC)
            {
                Console.WriteLine("The sample corresponds to the distribution.");
            }
            else
            {
                Console.WriteLine("The sample doesn't correspond to the distribution.");
            }

            //float ShermanN = Convert.ToSingle((Sherman - Math.Pow(N / (N + 1), N + 1)) / Math.Sqrt(((Math.Pow(2 * N, N + 2) + N * Math.Pow(N - 1, N + 2)) / (N + 2) * Math.Pow(N + 1, N + 2) - Math.Pow(N / (N + 1), 2 * N + 2))));

        }
    }
}