using System;

namespace Task_01
{
    class Program
    {
        static string DigitToString(char digit)
        {
            string[] digitString = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            return digitString[digit - '0'];
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int n;
            int per;
            do
            {
                Console.WriteLine("Введите размер массива:");
            } while (!int.TryParse(Console.ReadLine(), out n) && n > 1);
            do
            {
                Console.WriteLine("Введите процент букв:");
            } while (!int.TryParse(Console.ReadLine(), out per) && per >= 0);
            string[] arr = new string[n];
            int nLetterAmount = (int)(n * per / 100.0);
            for (int i = 0; i < nLetterAmount; i++)
            {
                arr[i] = ((char)random.Next('a', 'z' + 1)).ToString();
            }
            for (int i = nLetterAmount; i < n; i++)
            {
                arr[i] = DigitToString((char)random.Next('0', '9' + 1));
            }
            Array.ForEach(arr, x => Console.Write(x + " "));
        }
    }
}
