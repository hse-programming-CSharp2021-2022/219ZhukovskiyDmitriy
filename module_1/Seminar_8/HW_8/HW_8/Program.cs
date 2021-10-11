using System;

namespace HW_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            int a = int.Parse(Console.ReadLine());
            int[][] arr = new int[a][];
            for (int i = 0; i < arr.Length; i++)
            {
                int k = arr.Length;
                int p = 1;
                arr[i] = new int[a];
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (i == 0)
                    {
                        arr[i][j] = (k * i) + i + j + 1;
                    }
                    if (i % 2 == 0 && i != 0)
                    {
                        arr[i][j] = arr[i - 1][j] + p;
                        p += 2;
                    }
                    if (i % 2 != 0 && i != 0)
                    {
                        arr[i][j] = arr[i - 1][j] + k + k - 1;
                        k--;
                    }
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine();
            }


        }
    }
}
