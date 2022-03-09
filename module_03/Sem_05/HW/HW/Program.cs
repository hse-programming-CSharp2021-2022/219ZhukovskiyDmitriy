using System;

namespace HW
{
    public delegate double Calculate(double num);
    public interface IFunction
    {
        public double Function(double x);
    }
    internal class F : IFunction
    {
        private Calculate Calc { get; }

        public double Function(double x) => Calc(x);

        public F(Calculate calc) => Calc = calc;
    }

    internal class G
    {
        private F f;
        private F g;
        public G(F f, F g)
        {
            this.f = f;
            this.g = g;
        }

        public double GF(double x) => g.Function(f.Function(x));
    }

    class Program
    {
        private static void Main()
        {
            Calculate f1 = (double x) => x * x - 4;
            Calculate f2 = (double x) => Math.Sin(x);
            G g = new(new F(f2), new F(f1));
            for (double i = 0; i <= Math.PI; i += Math.PI / 16)
            {
                Console.WriteLine($"{g.GF(i):f4}");
            }
        }
    }
}