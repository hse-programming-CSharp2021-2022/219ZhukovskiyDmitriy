using System;

namespace ASCIIDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string s1 = Console.ReadLine();
            int Code;
            if (!int.TryParse(s1, out Code))
            {
                Console.WriteLine("Неверный ввод");
                return;
            }
            if (Code < 32 || Code > 127)
            {
                Console.WriteLine("Введите число из диапазона");
                return;
            }
            else
            {
                Console.WriteLine((char)Code);
            }
        }
    }
}
