using System;

namespace Task04
{
    class Program
    {
        public static int Reverser(string x)
        {
            char[] rev;
            string q = "";
            int num;
            rev = x.ToCharArray();
            Array.Reverse(rev);
            for (int i = 0; i < rev.Length; i++)
            {
                q = q + rev[i];
            }
            num = Convert.ToInt32(q);
            return num;
        }
        static void Main(string[] args)
        {
            int input;
            string x;
            do
            {
                do Console.Write("Введите четырехзначное число: ");
                while (!int.TryParse(Console.ReadLine(), out input) | input.ToString().Length != 4);
                x = input.ToString();
                Console.WriteLine(Reverser(x));
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
