using System;

namespace Task_03
{
    class Program
    {
        public static void MultAndDel(out int a, out int b)
        {
            int multuple = 0;
            int del = 0;
            int k = 1;
            int m = 1;
            do Console.Write("Введите первое число: ");
            while (!int.TryParse(Console.ReadLine(), out a));
            do Console.Write("Введите второе число: ");
            while (!int.TryParse(Console.ReadLine(), out b));
            for (int i = 1; i <= a; i++)
            {
                for (int j = 1; j <= b; j++)
                {
                    if (a % i == 0 && b % j == 0 && i == j)
                    {
                        del = i;
                    }
                }
            }
            Console.WriteLine("НОД:"+del);
            while (a * k != b * m)
            {
                
                if (b*m > a*k)
                {
                    k += 1;
                }
                if (b * m < a * k)
                {
                    m += 1;
                }
            }
            multuple = b * m;
            
            Console.WriteLine("НОК:"+ multuple);
        }
        static void Main(string[] args)
        {
            int a;
            int b;
            MultAndDel(out a, out b);
        }
    }
}
