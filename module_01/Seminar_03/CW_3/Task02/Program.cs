using System;
using static System.Math;
namespace Task02
{
    class Program
    {
        static void F1()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.Write(Pow(i, 2) + " ");
            }

        }
        static void F2()
        {
            int i = 1;
            while (i < 10)
            {
                Console.Write(Pow(i, 2) + " ");
                i++;
            }

        }
        static void F3()
        {

            int i = 1;
            do
            {
                Console.Write(Pow(i, 2) + " ");
                i++;
            } while (i < 10);

        }

        static void Main(string[] args)
        {
            F1();
            F2();
            F3();
        }
    }
}
