using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CW_12
{  
    class Program
    {
        static void Main(string[] args)
        {
            string[] name = { "Fdsfs", "Atreh", "Htr", "Wer", "acxc" };
            List<string> str = new();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i].ToUpper().StartsWith("A"))
                    str.Add(name[i]);
            }
            foreach (var it in str)
            {
                Console.WriteLine(it + " ");
            }
            var str2 = from i in name
                       where i.ToUpper().StartsWith("A")
                       select i;
            foreach (var it in str2)
            {
                Console.WriteLine(it + " ");
            }
            name = name.Where(x => x.StartsWith("A")).ToArray();
            int n = Convert.ToInt32(Console.ReadLine());
            int[] mas = new int[n];
            Random random = new();
            for (int i = 0; i < n; i++)
            {
                mas[i] = random.Next(1, 10001);
            }
            List<int> list = new();
            list.AddRange(mas);
            Console.WriteLine("Первый запрос");
            var req1 = list.Where(x => x.ToString().Length == 2 && x % 3 == 0);
            foreach (var it in req1)
            {
                Console.Write(it + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Четвертый запрос");
            var req4 = list.Where(x => x.ToString().Length == 4).Sum();
            Console.WriteLine(req4);
            Console.WriteLine("Пятый запрос");
            var req5 = list.Where(x => x.ToString().Length == 2).Min();
            Console.WriteLine(req5);
            string s = "вапап вап";
            Regex regex = new(@"вап\w*");
            var matches = regex.Matches(s);
            foreach (Match m in matches)
            {
                Console.WriteLine(m.Value);
            }
            string s2 = "111-111-1111";
            Regex regex1 = new Regex(@"\d{3}-[0-9]{3}-\d{4}");
            Console.WriteLine(regex1.Match(s2));
            Console.WriteLine(Regex.IsMatch(s2, @"\d{3}-[0-9]{3}-\d{4}"));
        }
    }
}
