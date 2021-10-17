using System;

namespace Task_03
{
    
    class Program
    {
        public static void Edit(int[] mas, int n)
        {
            int k = n - 6;
            for (int i = 0; i < mas.Length; i++)
            {
                if (i < mas.Length - 2)
                {
                    if ((mas[i] + mas[i + 1]) % 3 == 0)
                    {
                        mas[i] = mas[i] * mas[i + 1];

                        k = k + 1;

                    }
                    else
                    {
                        mas[i] = mas[i];

                        k = k + 1;

                    }

                }
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (j < mas.Length - 1)
                    {
                        mas[j] = mas[j + 1];

                    }

                }
            }
            Console.WriteLine();
            Console.Write("Отредактированный массив: ");
            for (int i = 0; i < k - 1; i++)
            {
                Console.Write(mas[i] + " ");
            }
        }
        static void Main(string[] args)
        {
            int n = 6;
            int[] mas = new int[n];
            Random random = new Random();
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = random.Next(1, 11);
            }
            Console.Write("Сформированный массив: ");
            foreach (var item in mas)
            {
                Console.Write(item + " ");
            }
            Edit(mas, n);
            
            
        }
    }
}
