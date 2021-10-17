using System;

namespace Task_01
{
    class Program
    {
        public static void NorMas(ref double[] mas, double N)
        {
            double max = mas[0];
            for (uint i = 0; i < N; i++)
            {
                if (i != N - 1)
                {
                    if (mas[i] < mas[i + 1])
                    {
                        max = mas[i + 1];
                    }
                }
            }
     
            
            for (uint i = 0; i < N; i++)
            {
                mas[i] = Math.Round(mas[i] / max,3);
                
            }
            for (uint i = 0; i < N; i++)
            {
                Console.Write(mas[i] + "\t");
            }
        }
        public static void PrintMas(ref double[] mas, uint N)
        {
            for (uint i = 0; i < N; i++)
            {
                Console.Write(mas[i] + "\t");
            }
        }
        static void Main(string[] args)
        {
            uint N;
            do
            {
                Console.Write("Введите натуральное число: ");
            } while (!uint.TryParse(Console.ReadLine(), out N));
            double[] mas = new double[N];
            for (uint i = 0; i < N; i++)
            {
                mas[i] = (i * (i + 1) / 2) % N;
            }
            Console.WriteLine("Исходный массив: ");
            PrintMas(ref mas, N);
            Console.WriteLine();
            Console.WriteLine("Форматированный массив: ");
            NorMas(ref mas, N);
        }
    }
}
