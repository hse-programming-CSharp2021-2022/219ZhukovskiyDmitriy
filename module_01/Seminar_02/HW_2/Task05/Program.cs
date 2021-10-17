using System;

namespace Task05
{
    class Program
    {
        public static void TriangleCheck(double a, double b, double c)
        {
            while (a+b < c | a+c<b| b+c<a)
            {
                Console.WriteLine("Треугольника с такими сторонами не существует.");
                break;
            }
            while (a+b>c & a+c>b &b+c>a)
            {
                Console.WriteLine("Треугольник с такими сторонами возможен.");
                break;
            }
        }
        static void Main(string[] args)
        {
            double a, b, c;
            do
            {
                do Console.Write("Введите A: ");
                while (!double.TryParse(Console.ReadLine(), out a) | a <= 0);
                do Console.Write("Введите B: ");
                while (!double.TryParse(Console.ReadLine(), out b) | b <= 0) ;
                do Console.Write("Введите C: ");
                while (!double.TryParse(Console.ReadLine(), out c) | c <= 0) ;
                TriangleCheck(a, b, c);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
