using System;

namespace Task_02
{
    class Program
    {
        public static int Changer(string k)
        {
            string m = "";
            int num;
            char[] arr = k.ToCharArray();
            Array.Sort(arr);
            Array.Reverse(arr);
            for (int i=0; i < arr.Length; i++)
            {
                m = m + arr[i];
            }
            num = Convert.ToInt32(m);
            return num;
            
        }
        static void Main(string[] args)
        {
            string k;
            int x;
            do
            {
                do Console.Write("Введите трехзначное число: ");
                while (!int.TryParse(Console.ReadLine(), out x) | (x.ToString().Length !=3));
                k = x.ToString();
                Console.WriteLine(Changer(k)); 
                Console.WriteLine("Выход - ESC");
                
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
