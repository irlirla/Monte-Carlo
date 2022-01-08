namespace Integral
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please, enter number of iterations N=");
            int N = Console.Read();

            double[,] points = MonteCarlo.RandomPointsInMyArea(N);

            double integralResult = MonteCarlo.MonteCarloMethod(points);

            Console.WriteLine("Monte-Carlo method's result: ", integralResult);
            Console.WriteLine("The difference between resice result and MCm result: ", Math.Abs(integralResult - 1/126));

        }
    }
}