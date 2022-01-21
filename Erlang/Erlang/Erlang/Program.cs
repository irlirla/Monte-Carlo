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
            List<double> xs = new();
            List<double> ys = new();
            var rand = MTRandom.Create();

            for (int i = 0; i < N; i++)
            {
                double x = rand.NextSingle();
                double y = rand.NextSingle();
                double xx = -Math.Log(x) / la;
                double yy = -Math.Log(y) / mu;
                xs.Add(xx);
                ys.Add(yy);

                points.Add(new Point()
                {
                    X = xx + yy,
                    Y = default
                });
            }

            //foreach (Point point in points)
            //{
            //    point.Y = mu * la * (Math.Exp(-mu * point.X) - Math.Exp(-la * point.X)) / (la - mu);
            //}

            const string file = "Points.txt";

            using (StreamWriter sw = new StreamWriter(file, true))
            {
                foreach (Point point in points)
                {
                    sw.WriteLine($"{point.X}");
                }
            }

            List<double> Epoints = new();
            foreach (Point point in points)
            {
                Epoints.Add(Distributions.ErlangToRavn(point.X, la, mu));
            }

            List<double> Upoints = new();

            for (int i = 0; i <= N + 1; i++)
            {
                Upoints.Add(new double());
            }

            for (int i = 1; i <= N; i++)
            {
                Upoints[i] = Epoints[i - 1];
            }
            Upoints[0] = 0.0d;
            Upoints[N + 1] = 1.0d;
            Upoints.Sort();

            double Sherman = 0;
            Console.Write("Please, enter value of alpha= "); //0.05f
            float alpha = float.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                Sherman = Sherman + Math.Abs(Upoints[i] - Upoints[i - 1] - 1 / (N + 1));
            }
            Sherman = Sherman / 2;
            Console.WriteLine($"Shermans statistics is {Sherman}.");
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