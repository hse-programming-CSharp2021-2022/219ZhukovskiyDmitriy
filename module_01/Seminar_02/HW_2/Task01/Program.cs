using System;


namespace Task_01
{
    class Program
    {
        public static int Polinom(int x)
        {
            int formula = x * (x * (x * (x+x+x+x+x+x+x+x+x+x+x+x+9) - 3) + 2) - 4;
            return formula;
        }
        static void Main(string[] args)
        {
            int x;
            do
            {
                do Console.Write("Введите число: ");
                while (!int.TryParse(Console.ReadLine(), out x));
                Console.WriteLine(Polinom(x));
                Console.WriteLine("Выход - ESC");

            } 
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        
    }
}
