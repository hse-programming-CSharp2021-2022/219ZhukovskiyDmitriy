using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_02
{
    class RegularPolygon
    {
        public double Radius { get; set; }
        public double Sides { get; set; }
        public RegularPolygon(double curRadius = 0, double curSides = 0)
        {
            Radius = curRadius;
            Sides = curSides;
        }
        public double Perimeter()
        {
            return 2 * Radius * Math.Tan(Math.PI / 2 / Sides);
        }
        public double Square()
        {
            return Sides * Radius * Radius * Math.Tan(Math.PI / 2 / Sides);
        }
        public static void PolygonData(RegularPolygon polygon)
        {
            Console.WriteLine($"Радиус: {polygon.Radius}\n" + $"Колличество сторон: {polygon.Sides}\n" + $"Периметр: {polygon.Perimeter()}\n" + $"Площадь: {polygon.Square()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var polygons = new List<RegularPolygon>();
            var squares = new List<double>();
            double radius;
            int sides;
            do
            {
                Console.WriteLine("Создайте новый многоугольник: ");
                Console.Write("Введите значение радиуса: ");
                while (!double.TryParse(Console.ReadLine(), out radius) || radius < 0)
                {
                    Console.WriteLine();
                    Console.Write("Введите корректное значение радиуса: ");

                }
                Console.Write("Введите количество сторон: ");

                while (!int.TryParse(Console.ReadLine(), out sides) || sides < 0)
                {
                    Console.WriteLine();
                    Console.Write("Введите корректное количество сторон: ");

                }
                if (sides != 0 && radius != 0)
                {
                    RegularPolygon polygon = new(radius, sides);
                    polygons.Add(polygon);
                    squares.Add(polygon.Square());
                }
                Console.WriteLine();
            } while (sides != 0 && radius != 0);
            for (int i = 0; i < polygons.Count; i++)
            {
                if (squares[i] == squares.Max())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    RegularPolygon.PolygonData(polygons[i]);
                    Console.WriteLine();

                }
                if (squares[i] == squares.Min())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    RegularPolygon.PolygonData(polygons[i]);
                    Console.WriteLine();
                }
                if (squares[i] != squares.Min() && (squares[i] != squares.Max()))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    RegularPolygon.PolygonData(polygons[i]);
                    Console.WriteLine();

                }
            }
        }
    }
}