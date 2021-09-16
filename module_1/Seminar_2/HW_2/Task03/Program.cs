using System;

namespace Task03
{
    class Program
    {
        public static void Calculus(double a, double b, double c)
        {
            double D = (b * b - 4 * a * c);
            double x1 = (-b + Math.Sqrt (D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            
            while (D > 0)
            {
                Console.WriteLine("Первый корень: {0}", x1);
                Console.WriteLine("Второй корень: {0}", x2);
                Console.WriteLine("Комплексных корней нет.");
                break;
            }
            while (D == 0)
            {
                Console.WriteLine("Корень: {0}", x1);
                Console.WriteLine("Комплексных корней нет.");
                break;
            }
            while (D < 0)
            {
                Console.WriteLine("Комплексные корни есть.");
                break;
            }
        }
        static void Main(string[] args)
        {
            double a, b, c;
            do
            {
                do Console.Write("Введите A: ");
                while (!double.TryParse(Console.ReadLine(), out a) | a == 0);
                do Console.Write("Введите B: ");
                while (!double.TryParse(Console.ReadLine(), out b)) ;
                do Console.Write("Введите C: ");
                while (!double.TryParse(Console.ReadLine(), out c)) ;
                Calculus(a, b, c);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
