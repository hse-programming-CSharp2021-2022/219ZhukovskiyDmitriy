using System;

namespace Task_02
{
    class Program
    {
        public static int Fact(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Fact(x-1);
            }
        }
        public static void InfSum1(double x)
        {
            double S = 0;
            int j = 2;
            int k = 2;
            for (int i = 0; i<x;i++)
            {
                S += Math.Pow(-1, i) * (j * Math.Pow(x, k) / Fact(k));
                j = j * 4;
                k += 2;
            }
            Console.WriteLine(S);
        }
        public static void InfSum2(double x)
        {
            double S = 1;
            int m = 0;
            for (int i = 1; i < x+1; i++)
            {
                m = Fact(i);
                S += Math.Pow(x, i) / m;

            }
            Console.WriteLine(S);
        }
        static void Main(string[] args)
        {
            double x;
            Console.Write("Введите вещественное число: ");            
            while (!double.TryParse(Console.ReadLine(), out x));
            InfSum1(x);
            InfSum2(x);
        }
    }
}
