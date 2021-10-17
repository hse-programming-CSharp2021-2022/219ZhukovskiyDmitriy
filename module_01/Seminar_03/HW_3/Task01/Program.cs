using System;

namespace Task01
{

    class Program
    {
        public static void G(double x, double y)
        {
            if (x < 0 | y < -2 | y > Math.Sqrt(2) | x * x + (y * y) > 4)
            {
                Console.WriteLine(false);
            }
            if ((x >= 0 & x <= 2) & (y <= Math.Sqrt(2) & y >= -2) & x * x + y * y <= 4)
            {
                Console.WriteLine(true);
            }
        }
        static void Main(string[] args)
        {

            double x;
            double y;
            Console.Write("Введите x: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Неверный ввод.");
                Console.Write("Введите x: ");
            }
            Console.Write("Введите y: ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Неверный ввод.");
                Console.Write("Введите y: ");
            }
            G(x, y);
        }
    }
}
