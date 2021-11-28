using System;
// 2_03a, task 4
namespace Task_01
{
    public class Shape
    {
        public const double PI = Math.PI;
        protected double _x, _y;

        public Shape()
        {
        }

        public Shape(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public virtual double Area()
        {
            return _x * _y;
        }
    }

    public class Circle : Shape
    {
        public Circle(double r) : base(r, 0)
        {
        }

        public override double Area()
        {
            return PI * _x * _x;
        }
        public override string ToString()
        {
            return "Circle";
        }
    }

    public class Sphere : Shape
    {
        public Sphere(double r) : base(r, 0)
        {
        }

        public override double Area()
        {
            return 4 * PI * _x * _x;
        }
        public override string ToString()
        {
            return "Sphere";
        }
    }

    public class Cylinder : Shape
    {
        public Cylinder(double r, double h) : base(r, h)
        {
        }

        public override double Area()
        {
            return 2 * PI * _x * _x + 2 * PI * _x * _y;
        }
        public override string ToString()
        {
            return "Cylinder";
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Random random = new();
            int N1 = random.Next(3, 6);
            int N2 = random.Next(3, 6);
            int N3 = random.Next(3, 6);
            Shape[] shapes = new Shape[N1 + N2 + N3];
            Console.WriteLine("Реализация пункта 2");
            Console.WriteLine();
            for (int i = 0; i < shapes.Length; i++)
            {

                int x = random.Next(0, 3);
                if (x == 0)
                {
                    Circle circle = new(random.NextDouble() * 50);
                    shapes[i] = circle;
                    Console.WriteLine("Площадь круга:" + circle.Area());
                }
                if (x == 1)
                {
                    Cylinder cylinder = new(random.NextDouble() * 50, random.NextDouble()*50);
                    shapes[i] = cylinder;
                    Console.WriteLine("Площадь поверхности цилиндра:" + cylinder.Area());
                }
                if (x == 2)
                {
                    Sphere sphere = new(random.NextDouble() * 50);
                    shapes[i] = sphere;
                    Console.WriteLine("Площадь поверхности сферы:" + sphere.Area());
                }

            }
            Console.WriteLine();
            Console.WriteLine("Реализация пункта 3");
            Console.WriteLine();
            for (int i = 0; i < shapes.Length; i++)
            {
                if (shapes[i] is Circle)
                {
                    Console.WriteLine("Круг; площадь: " + shapes[i].Area());
                }
                if (shapes[i] is Cylinder)
                {
                    Console.WriteLine("Цилиндр; площадь поверхности: " + shapes[i].Area());
                }
                if (shapes[i] is Sphere)
                {
                    Console.WriteLine("Сфера; площадь поверхности: " + shapes[i].Area());
                }
            }
            Console.WriteLine();
            Console.WriteLine("Реализация пункта 4");
            Console.WriteLine();
            int Compare(Shape x, Shape y)
            {
                if (x is Circle && y is Cylinder)
                {
                    return -1;
                }
                if (x is Circle && y is Sphere)
                {
                    return -1;
                }
                if (x is Cylinder && y is Sphere)
                {
                    return -1;
                }
                if (x is Cylinder && y is Circle)
                {
                    return 1;
                }
                if (x is Sphere && y is Circle)
                {
                    return 1;
                }
                if (x is Sphere && y is Cylinder)
                {
                    return 1;
                }
                return 0;
            }
            
            Array.Sort(shapes, Compare);
            foreach (var item in shapes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
