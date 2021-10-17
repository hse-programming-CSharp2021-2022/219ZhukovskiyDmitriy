using System;
using static System.Math;
namespace Task03
{
    class Program
    {
        public static void G(double x)
        {
            if (x <= 0.5)
            {
                Console.WriteLine(Sin(PI / 2.0));
            }
            if (x > 0.5)
            {
                double y = PI * (x - 1) / 2.0;
                Console.WriteLine(Sin(y));
            }
        }
        static void Main(string[] args)
        {
            double x;
            Console.Write("Введите x: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Неверный ввод.");
                Console.Write("Введите x: ");
            }
            Console.Write("Ответ в радианах: ");
            G(x);
        }
    }
}
