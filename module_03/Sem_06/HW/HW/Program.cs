using System;
using System.Collections.Generic;

namespace HW
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
        }

        public override string ToString()
        {
            return $"Координаты: ({X};{Y})";
        }
    }

    class Circle : IComparable<Circle>
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public Circle(double x, double y, double radius) => (Center, Radius) = (new Point(x, y), radius);

        public override string ToString() => $"Радиус: {Radius}. Центр: {Center}";

        public int CompareTo(Circle other)
        {
            if (this.Radius * this.Center.Distance(new Point(0, 0)) > other.Radius * other.Center.Distance(new Point(0, 0)))
                return 1;
            else if (this.Radius * this.Center.Distance(new Point(0, 0)) < other.Radius * other.Center.Distance(new Point(0, 0)))
                return -1;
            else
                return 0;
        }
    }

    class Program
    {
        static void Main()
        {

            List<Circle> circles = new();
            Console.WriteLine("До сортировки:\n");
            for (int i = 0; i < 10; i++)
            {
                circles.Add(new Circle(new Random().Next(-100,101), new Random().Next(-100,101),
                    new Random().Next(-100,101)));
                Console.WriteLine(circles[i]);
            }
            Console.WriteLine("\nПосле сортировки:\n");
            //circles.Sort((x, y) => (x.Radius * x.Center.Distance(new Point(0, 0))).
            //   CompareTo(y.Radius * y.Center.Distance(new Point(0, 0))));

            circles.Sort((firstCircle, secondCircle) => firstCircle.CompareTo(secondCircle));

            foreach (var item in circles)
            {
                Console.WriteLine(item);
            }

        }
    }


    struct SCircle
    {
        public SPoint Center { get; set; }
        public double Radius { get; set; }

        public SCircle(double x, double y, double radius) => (Center, Radius) = (new SPoint(x, y), radius);

        public override string ToString() => $"Радиус: {Radius}. Центр: {Center}";
    }

    struct SPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public SPoint(double x, double y) => (X, Y) = (x, y);

        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
        }

        public override string ToString()
        {
            return $"Координаты: ({X};{Y})";
        }
    }
}
