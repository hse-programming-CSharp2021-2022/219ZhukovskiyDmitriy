using System;
using System.Linq;
using System.Collections.Generic;
namespace HW
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = new();
            for (int i = 0; i < n; i++)
            {
                numbers.Add(rnd.Next(-1000, 1001));
            }

            Console.WriteLine("Исходная коллекция\n");

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----");

            Console.WriteLine("Квадраты\n");

            var squares = numbers.Select(x => x * x);
            foreach (var item in squares)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----");

            var twoDigits = numbers.Where(x => x > 0 && x.ToString().Length == 2);

            Console.WriteLine("Положительные двузначные\n");
            foreach (var item in twoDigits)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----");

            var sortebByDesc = numbers.Where(x=>x%2==0).OrderByDescending(y=>y);

            Console.WriteLine("Четные по убыванию\n");
            foreach (var item in sortebByDesc)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----");

            var groups = numbers.GroupBy(x => Math.Abs(x).ToString().Length).OrderBy(y=>y.Key);
            Console.WriteLine("Группы по порядку\n");
            foreach (var group in groups)
            {
                Console.WriteLine("Ключ: "+group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
