using System;

namespace Task_01
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }
        public double Ro
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }
        public double Phi
        {
            get
            {
                if (X > 0 && Y >= 0)
                {
                    return Math.Atan(Y / X);
                }
                if (X > 0 && Y < 0)
                {
                    return Math.Atan(Y / X) + Math.PI * 2;
                }
                if (X < 0)
                {
                    return Math.Atan(Y / X) + Math.PI;
                }
                if (X == 0 && Y > 0)
                {
                    return Math.PI / 2.0;
                }
                if (X == 0 && Y < 0)
                {
                    return Math.PI / 2.0 * 3.0;
                }
                return 0;
            }
        }
        public override string ToString()
        {
            return "X: " + X + "\n" + "Y: " + Y + "\n" + "Ro: " + Ro + "\n" + "Phi: " + Phi;
        }
    }
    class Program
    {
        public static void GetMaxMidMin(Point first, Point second, Point third)
        {
            if (first.Ro < Math.Min(second.Ro, third.Ro))
            {
                Console.WriteLine(first + "\n");
                if (second.Ro < third.Ro)
                {
                    Console.WriteLine(second + "\n");
                    Console.WriteLine(third);
                }
                else
                {
                    Console.WriteLine(third + "\n");
                    Console.WriteLine(second);
                }
            }
            if (second.Ro < Math.Min(first.Ro, third.Ro))
            {
                Console.WriteLine(second + "\n");
                if (first.Ro < third.Ro)
                {
                    Console.WriteLine(first + "\n");
                    Console.WriteLine(third);
                }
                else
                {
                    Console.WriteLine(third + "\n");
                    Console.WriteLine(first);
                }
            }
            if (third.Ro < Math.Min(first.Ro, second.Ro))
            {
                Console.WriteLine(third + "\n");
                if (first.Ro < second.Ro)
                {
                    Console.WriteLine(first + "\n");
                    Console.WriteLine(second);
                }
                else
                {
                    Console.WriteLine(second + "\n");
                    Console.WriteLine(first);
                }
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ваша первая точка: ");
            Point first = new Point(5, 5);
            Console.WriteLine(first);
            Console.WriteLine();
            Console.WriteLine("Ваша вторая точка: ");
            Point second = new Point(13, 7);
            Console.WriteLine(second);
            Console.WriteLine();
            double x = 0;
            double y = 0;
            do
            {
                Console.WriteLine("Создайте третью точку!");
                while (!double.TryParse(Console.ReadLine(), out x))
                {
                    Console.Write("Введите координату x заново: ");
                    Console.WriteLine();
                }
                while (!double.TryParse(Console.ReadLine(), out y))
                {
                    Console.Write("Введите координату y заново: ");
                    Console.WriteLine();
                }
                if (x != 0 && y != 0)
                {
                    Point third = new Point(x, y);
                    Console.WriteLine("Ваша третья точка:" + "\n" + third + "\n");
                    Console.WriteLine("Вывод данных о точках в порядке возрастания их расстояний от начала координат:");
                    GetMaxMidMin(first, second, third);
                    Console.WriteLine();
                }
            } while (x != 0 && y != 0);

        }
    }
}
