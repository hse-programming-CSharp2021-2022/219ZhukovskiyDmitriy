using System;

namespace Task04
{
    class Program
    {
        public static void FindMin(int x, int y, int z)
        {
            string s1 = x.ToString();
            string s2 = y.ToString();
            string s3 = z.ToString();
            string ns1 = s1[1].ToString() + s1[2].ToString();
            string ns2 = s2[1].ToString() + s2[2].ToString();
            string ns3 = s3[1].ToString() + s3[2].ToString();
            int num1 = Convert.ToInt32(ns1);
            int num2 = Convert.ToInt32(ns2);
            int num3 = Convert.ToInt32(ns3);

            if (num1 > num2 & num1 > num3)
            {
                Console.WriteLine("Наибольший номер на своем этаже: " + num1);
            }
            if (num2 > num1 & num2 > num3)
            {
                Console.WriteLine("Наибольший номер на своем этаже: " + num2);
            }
            if (num3 > num2 & num3 > num1)
            {
                Console.WriteLine("Наибольший номер на своем этаже: " + num3);
            }
            if (num1 == num2 & num1 > num3)
            {
                Console.WriteLine("Наибольший номер на своем этаже: " + num1);
            }
            if (num1 == num3 & num1 > num2)
            {
                Console.WriteLine("Наибольший номер на своем этаже: " + num1);
            }
            if (num2 == num3 & num2 > num1)
            {
                Console.WriteLine("Наибольший номер на своем этаже: " + num2);
            }
            if (num2 == num3 & num2 == num1)
            {
                Console.WriteLine("Наибольший номер на своем этаже: " + num2);
            }

        }
        static void Main(string[] args)
        {
            int x;
            int y;
            int z;
            Console.Write("Введите номер первой аудитории: ");
            while (!int.TryParse(Console.ReadLine(), out x) | x.ToString().Length != 3)
            {
                Console.WriteLine("Неверный ввод.");
                Console.Write("Введите номер первой аудитории: ");
            }
            Console.Write("Введите номер первой аудитории: ");
            while (!int.TryParse(Console.ReadLine(), out y) | y.ToString().Length != 3)
            {
                Console.WriteLine("Неверный ввод.");
                Console.Write("Введите номер первой аудитории: ");
            }
            Console.Write("Введите номер третьей аудитории: ");
            while (!int.TryParse(Console.ReadLine(), out z) | z.ToString().Length != 3)
            {
                Console.WriteLine("Неверный ввод.");
                Console.Write("Введите номер третьей аудитории: ");
            }
            FindMin(x, y, z);
        }
    }
}
