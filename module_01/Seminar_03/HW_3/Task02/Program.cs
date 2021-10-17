using System;

namespace Task02
{
    class Program
    {
        public static void G(double x, double y)
        {
            while (true)
            {
                if (x < y & x > 0)
                {
                    Console.WriteLine("x+sin(y) = " + (x + Math.Sin(y)));
                    break;
                }
                if (x > y & x < 0)
                {
                    Console.WriteLine("y - cos(x) = " + (y - Math.Cos(x)));
                    break;
                }
                else
                {
                    Console.WriteLine("0.5 * x * y = " + (0.5 * x * y));
                    break;
                }
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
