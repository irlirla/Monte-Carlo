namespace Integral
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please, enter number of iterations N=");
            int N = Console.Read();

            Point[] points = Methods.ThrowPoints(N);



            //Console.WriteLine("Monte-Carlo mean method's result: ", result);
            //Console.WriteLine("The difference between accurate result and MCmm result: ", Math.Abs(result - 1/126));

            double geomResult = Methods.GeometricMethod(points);
        }
    }
}