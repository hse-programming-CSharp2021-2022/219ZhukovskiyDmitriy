using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Напряжение: ");
            string s1 = Console.ReadLine();
            double U;
            if (!double.TryParse(s1,out U))
            {
                Console.WriteLine("Неверное значение");
                return;
            }
            Console.Write("Сопротивление: ");
            string s2 = Console.ReadLine();
            double R;
            if (!double.TryParse(s2, out R))
            {
                Console.WriteLine("Неверное значение");
                return;
            }
            Console.WriteLine("Сила тока равна: " + (U / R));
            Console.WriteLine("Потребляемая мощность равна: " + (Math.Pow(U,2) / R));
        }
    }
}
