using System;

namespace CW_8
{
    class Program
    {
        
        public static void Print(ref int[,,] mas, int x)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    for (int k = 0; k < x; k++)
                    {
                        Console.Write(mas[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            int x = int.Parse(Console.ReadLine());
            Random random = new Random();
            int[][] mas = new int[x][];
            for (int i = 0; i < x; i++)
            {
                mas[i] = new int[random.Next(5, 16)];
            }
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < mas[i].GetLength(0); j++)
                {
                    mas[i][j] = random.Next(-10, 11);
                }
            }

            Array.Sort(mas, (a, b) =>
            {
                if (a.Length > b.Length) return -1;
                if (a.Length < b.Length) return 1;
                return 0;
            });
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < mas[i].GetLength(0); j++)
                {
                    Array.Sort(mas[i], (a, b) =>
                    {
                        if (a > b) return -1;
                        if (a < b) return 1;
                        return 0;
                    });
                }
            }
            Array.ForEach(mas, el =>
             {
                 Array.ForEach(el, el =>
                 {
                     Console.Write(el+" ");

                 });
                 Console.WriteLine();
             });
            

        }
    }
}
