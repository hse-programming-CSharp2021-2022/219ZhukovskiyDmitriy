using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int rand = random.Next(0, 101);
            int[] mas = new int[100];
            for (int i = 0; i < 100; i++)
            {
                mas[i] = i+1;
                if (i==rand && i==0)
                {
                    mas[i] = random.Next(2, 101);
                    while (mas[i] == i + 1)
                    {
                        mas[i] = random.Next(2, 101);
                    }
                }
                if (i == rand)
                {
                    mas[i] = random.Next(1, 101);
                    while (mas[i] == i+1)
                    {
                        mas[i] = random.Next(1, 101);
                    }
                }
            }            
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.Write(mas[i] + " ");
            //}
            //Console.WriteLine();
            Console.Write(mas[rand]);
           
        }
    }
}
