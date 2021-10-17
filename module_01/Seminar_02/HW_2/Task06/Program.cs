using System;
using System.Security.Cryptography.X509Certificates;

namespace Task06
{
    class Program
    {
        public static void PlayCount(double sum, int percent)
        {
            double play = sum * percent / 100;
            Console.WriteLine(play + " рублей выделено на видеоигры.");
        }
        static void Main(string[] args)
        {
            double sum;
            int percent;
            do
            {
                do Console.Write("Бюджет пользователя (в рублях): ");
                while (!double.TryParse(Console.ReadLine(), out sum) | sum <= 0);
                do Console.Write("Процент, выделенный на видеоигры: ");
                while (!int.TryParse(Console.ReadLine(), out percent) | percent < 0 | percent > 100);
                PlayCount(sum, percent);
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
