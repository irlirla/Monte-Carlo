using Integral.Tasks;

namespace Integral
{
    class Program
    {
        static void Main()
        {
            double iAccurate = 0.1111111111111;
            Console.WriteLine("Please, choose:\n1. I want to enter the number of iterations N.\n2. I want to enter the probability error.");
            string answer = Console.ReadLine();

            if (answer is "1")
            {
                Console.Write("Please, enter number of iterations N=");
                int N = int.Parse(Console.ReadLine());

                (double, double) meanResult = IMethods.MeanMethod(N);

                Console.WriteLine($"Monte-Carlo mean method result: {meanResult.Item1}");
                Console.WriteLine($"The difference between accurate result and MCmm result: {Math.Abs(meanResult.Item1 - iAccurate)}");

                Console.WriteLine($"Dispersion of Mean Method is {meanResult.Item2}.");

                Console.WriteLine("\nLets try out the Geometric Method.");
                List<Point> points = IMethods.ThrowPoints(N);
                double geomResult = IMethods.GeometricMethod(points);

                Console.WriteLine($"Monte-Carlo geometric method result: {geomResult}");
                Console.WriteLine($"The difference between accurate result and MCgm result: {Math.Abs(geomResult - iAccurate)}");

                double DispersionGM = geomResult - geomResult * geomResult;
                Console.WriteLine($"Dispersion of Geometric Method is {DispersionGM}.");

                double RMM = 0.6745 * Math.Sqrt(meanResult.Item2 / N);
                double RGM = 0.6745 * Math.Sqrt(DispersionGM / N);
                Console.WriteLine($"\nThe probability error of Mean Method is {RMM} and of Geometric Method is {RGM}.");

                Console.WriteLine($"The efficienty of Mean Method is {meanResult.Item2 * ITime.MMTime(N)}.");
                Console.WriteLine($"The efficienty of Geometric Method is {DispersionGM * ITime.GMTime(N)}.");

                if (meanResult.Item2 * ITime.MMTime(N) > DispersionGM * ITime.GMTime(N))
                {
                    Console.WriteLine("So the Mean Method is more efficient.");
                }
                else
                {
                    Console.WriteLine("So the Geometric Method is more efficient.");
                }

                Console.WriteLine($"The difference(%) between methods efficienty is {Math.Abs(meanResult.Item2 * ITime.MMTime(N) / (DispersionGM * ITime.GMTime(N)))*100}");

                Console.ReadKey();
            }
            else if (answer is "2")
            {
                Console.WriteLine("Please, enter desired probability error: ");
                double R = double.Parse(Console.ReadLine());

                int NMM = Convert.ToInt32((0.04 - 0.1111111*0.1111111)*(0.6745 * 0.6745 / (R * R)));
                int NGM = Convert.ToInt32((iAccurate - iAccurate*iAccurate) * (0.6745 * 0.6745 / (R * R)));

                (double, double) meanResult = IMethods.MeanMethod(NMM);

                Console.WriteLine($"Monte-Carlo mean method result: {meanResult.Item1}");
                Console.WriteLine($"The difference between accurate result and MCmm result: {Math.Abs(meanResult.Item1 - iAccurate)}");
                
                Console.WriteLine($"Dispersion of Mean Method is {meanResult.Item2}.");

                Console.WriteLine("\nLets try out the Geometric Method.");
                List<Point> points = IMethods.ThrowPoints(NGM);
                double geomResult = IMethods.GeometricMethod(points);

                Console.WriteLine($"Monte-Carlo geometric method result: {geomResult}");
                Console.WriteLine($"The difference between accurate result and MCgm result: {Math.Abs(geomResult - iAccurate)}");

                double DispersionGM = geomResult - geomResult * geomResult;
                Console.WriteLine($"Dispersion of Geometric Method is {DispersionGM}.");

                Console.WriteLine($"\nThe efficienty of Mean Method is {meanResult.Item2 * ITime.MMTime(NMM)}.");
                Console.WriteLine($"The efficienty of Geometric Method is {DispersionGM * ITime.GMTime(NGM)}.");

                if (meanResult.Item2 * ITime.MMTime(NMM) > DispersionGM * ITime.GMTime(NGM))
                {
                    Console.WriteLine("So the Mean Method is more efficient.");
                }
                else
                {
                    Console.WriteLine("So the Geometric Method is more efficient.");
                }

                Console.WriteLine($"The difference(%) between methods efficienty is {Math.Abs(meanResult.Item2 * ITime.MMTime(NMM) / (DispersionGM * ITime.GMTime(NGM))) * 100}");

                Console.ReadKey();
            }
            else
            {
                while (answer is not "1" || answer is not "2")
                {
                    Console.WriteLine("Please, choose 1 or 2 option.");
                    Console.ReadKey();
                    break;
                }
            };
        }
    }
}