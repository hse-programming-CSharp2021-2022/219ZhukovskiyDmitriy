using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Длина первого катета: ");
            string s1 = Console.ReadLine();
            double first_side;
            if (!double.TryParse(s1, out first_side))
            {
                Console.WriteLine("Неверное значение");
                return;
            }
            Console.Write("Длина второго катета: ");
            string s2 = Console.ReadLine();
            double second_side;
            if (!double.TryParse(s2, out second_side))
            {
                Console.WriteLine("Неверное значение");
                return;
            }
            Console.WriteLine("Длина гипотенузы: " + (Math.Sqrt(first_side * first_side + second_side * second_side)));
        }
    }
}
