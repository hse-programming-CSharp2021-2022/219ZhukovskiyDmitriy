using System;

namespace Task_02
{
    class RegularPolygon
    {
        public int Count { get; set; }
        public double Radius { get; set; }
        public RegularPolygon(int curCount = 0, double curRadius = 0)
        {
            Count = curCount;
            Radius = curRadius;
        }

        public double Perimeter()
        {
            return 2 * Radius * Math.Tan(Math.PI / 2 / Count);
        }
        public double Square()
        {
            return Count * Radius * Radius * Math.Tan(Math.PI / 2 / Count);
        }
        public void PolygonData()
        {
            Console.WriteLine($"Радиус: {Radius}\n" +  $"Колличество сторон: {Count}\n" + $"Периметр: {Perimeter()}\n" + $"Площадь: {Square()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int Count = int.Parse(Console.ReadLine());
            double Radius = double.Parse(Console.ReadLine());
            RegularPolygon polygon = new RegularPolygon(Count, Radius);
            polygon.PolygonData();


        }
    }
}