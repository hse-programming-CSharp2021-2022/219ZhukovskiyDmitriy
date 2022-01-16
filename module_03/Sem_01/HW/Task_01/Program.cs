using System;

namespace Task_01
{
    class Program
    {
        public static int M1(double x)
        {
            return (int)(x / 2) * 2;
        }
        public static int M2(double x)
        {
            return (int)(Math.Log10(x)) + 1;
        }
        static void Main(string[] args)
        {
            Cast cast1 = delegate (double x)
            {
                return (int)(x % 2) == 0 ? (int)x : (int)x + 1;
            };
            Cast cast2 = (x) => (int)(Math.Log10(x)) + 1;
            Console.WriteLine(cast1(11.7));
            Console.WriteLine(cast2(110.7));
            Cast cast3 = cast1 + cast2;
            Console.WriteLine();
            Console.WriteLine(cast3?.Invoke(110.7));
            cast3 -= (x) => (int)(Math.Log10(x)) + 1;
            Console.WriteLine(cast3?.Invoke(110.7));
            Console.WriteLine("***");
            Cast cast4 = M1;
            Cast cast5 = M2;
            Console.WriteLine(cast4.Invoke(11.7));
            Console.WriteLine(cast5.Invoke(110.7));
            Cast cast6 = cast4 + cast5;
            Console.WriteLine();
            Console.WriteLine(cast6?.Invoke(110.7));
            Console.WriteLine(cast6?.Invoke(110.7));
            Console.WriteLine("***");
            foreach (Cast d in cast6.GetInvocationList())
            {
                Console.WriteLine(d?.Invoke(110.7));
            }
        }
        delegate int Cast(double a);
    }

}
}
