using System;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            uint x;
            do Console.Write("Введите число: ");
            while (!uint.TryParse(Console.ReadLine(), out x));
            string y = x.ToString();
            int x9 = 9;
            Console.Write("Отсортированное число: ");
            for (int i =x9; i>=0; i--)
            {
                for (int j = 0; j<y.Length;j++)
                {
                    if (i.ToString() == y[j].ToString())
                    {
                        Console.Write(i);
                    }
                }
            }
        }
    }
}
