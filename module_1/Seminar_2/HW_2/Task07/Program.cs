using System;

namespace Task07
{
    class Program
    {
        public static void Divider(double input)
        {
            int one = (int)input;
            double two = (input - one);
            Console.WriteLine("Целая часть: " + one);
            Console.WriteLine("Дробная часть: " + two);
        }
        public static void Maths(double input)
        {
            double up = input * input;
            Console.WriteLine("Число в квадрате: " + up);
            if (input >= 0.0)
                Console.WriteLine("Корень из числа: " + Math.Sqrt(input));
            else
            {
                Console.WriteLine("Из отрицательного числа нельзя взять квадратный корень");
            }
        }
        static void Main(string[] args)
        {
            double input;
            do
            {
                do Console.Write("Введите число: ");
                while (!double.TryParse(Console.ReadLine(), out input));
                Divider(input);
                Maths(input);
                Console.WriteLine("Выход - ESC");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
