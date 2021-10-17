using System;

namespace Task_02
{
    class Program
    {
        public static uint N(uint n)
        {                       
            if (n == 0)
            {
               return  1;
            }
            if (n==1)
            {
               return  2;
            }
            else
            {
                return  N(n - 1) + N(n - 1);
                
            }    
        }
        public static uint M(uint m)
        {
            if (m == 0)
            {
                return 1;
            }
            if (m == 1)
            {
                return 2;
            }
            else
            {
                return M(m - 1) + M(m - 1);

            }
        }
        static void Main(string[] args)
        {
            uint n;
            uint m;
            do Console.Write("Введите целое неотрицательное число: ");
            while (!uint.TryParse(Console.ReadLine(), out n));
            do Console.Write("Введите целое неотрицательное число: ");
            while (!uint.TryParse(Console.ReadLine(), out m));
            Console.WriteLine(N(n)+M(m));
        }
    }
}
