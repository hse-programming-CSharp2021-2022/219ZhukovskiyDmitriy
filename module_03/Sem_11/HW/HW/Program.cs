using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW
{
    internal class Program
    {
        static Random random = new();
        static void Main(string[] args)
        {
            using (var writer = new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (var i = 0; i < 10; i++)
                {
                    writer.Write(random.Next(1, 101));
                }
            }
            List<int> numbers = new();
            Console.WriteLine("Вывод сгенерированных чисел: ");
            using (var reader = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (var i = 0; i < 10; i++)
                {
                    numbers.Add(reader.ReadInt32());
                    Console.Write(numbers[i] + " ");
                }
            }
            Console.WriteLine();
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            if (n > 100 || n < 1)
            {
                Console.WriteLine("Число не приндлежит диапазону от 1 до 100!");
                for (var i = 0; i < 10; i++)
                {
                    Console.Write(numbers[i] + " ");
                }
                return;
            }
            else
            {
                int num = -1;
                int diff = 100;
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (Math.Abs(numbers[i] - n) < diff)
                    {
                        num = numbers[i];
                        diff = Math.Abs(numbers[i] - n);
                    }
                }
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == num)
                    {
                        numbers[i] = n;
                    }
                }
            }


            using (var writer = new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (var i = 0; i < 10; i++)
                {
                    writer.Write(numbers[i]);
                }
            }
            using (var reader = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (var i = 0; i < 10; i++)
                {
                    numbers[i] = reader.ReadInt32();
                    Console.Write(numbers[i] + " ");
                }
            }

        }
    }
}
