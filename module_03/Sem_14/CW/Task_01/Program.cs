using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_01
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
                numbers.Add(rnd.Next(-10000, 10001));
                Console.WriteLine(numbers[i]);
            }
            Console.WriteLine("----");
            var list1_1 = from nums in numbers
                          select nums.ToString()[nums.ToString().Length - 1];
            var list1_2 = numbers.Select(x => x.ToString()[x.ToString().Length - 1]);

            foreach (var item in list1_1)
            {
                Console.WriteLine(item);
            }
            foreach (var item in list1_2)
            {
                Console.WriteLine(item);
            }
            var list2_1 = from nums in numbers
                          group nums by nums.ToString()[nums.ToString().Length - 1] into nums2
                          select nums2;
            var list2_2 = numbers.GroupBy(nums => nums.ToString()[nums.ToString().Length - 1]);

            foreach (var item in list2_2)
            {
                Console.WriteLine(item.Key);
                foreach (var it in item)
                {
                    Console.WriteLine(it);
                }
            }
            

            var count3_1 = (from nums in numbers
                           where nums > 0 && nums % 2 == 0
                           select nums).Count();
            var count3_2 = numbers.Where(x => x > 0 && x % 2 == 0).Count();


            Console.WriteLine(count3_1);


            Console.WriteLine(count3_2);


            var sum4_1 = (from nums in numbers
                           where nums % 2 == 0
                           select nums).Sum();
            var sum4_2 = numbers.Where(x => x % 2 == 0).Sum();

            Console.WriteLine(sum4_1);


            Console.WriteLine(sum4_2);

            var list5_1 = from nums in numbers
                          orderby nums.ToString()[0], nums.ToString()[nums.ToString().Length - 1]
                          select nums;
            var list5_2 = numbers.OrderBy(x => x.ToString()[0]).ThenBy(x => x.ToString()[x.ToString().Length - 1]);

            foreach (var item in list5_1)
            {
                Console.WriteLine(item);
            }
            foreach (var item in list5_2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
