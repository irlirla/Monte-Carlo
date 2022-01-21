namespace Erlang
{
    public interface Distributions
    {
        public static double Pokaz(double x, double k)
        {
            return -Math.Log(x) / k;
        }

        public static double Erlang(double x, double l, double m)
        {
            return m * l * (Math.Exp(-m * x) - Math.Exp(-l * x)) / (l - m);
        }

        public static double ErlangToRavn(double x, double l, double m)
        {
            return 1 - (l * Math.Exp(-m * x) - m * Math.Exp(-l * x))/(l - m);
        }
    }
}
