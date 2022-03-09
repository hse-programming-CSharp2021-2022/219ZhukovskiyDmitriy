using System;

namespace HW
{
    delegate void CoordChanged(Dot dot);
    class Dot
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Dot(double x, double y)
        {
            X = x;
            Y = y;
        }
        public event CoordChanged OnCoordChanged;
        public void DotFlow()
        {
            Random random = new();
            for (int i = 0; i < 10; i++)
            {
                double x = -10 + 20 * random.NextDouble();
                double y = -10 + 20 * random.NextDouble();
                X = x;
                Y = y;
                if (x < 0 && y < 0)
                {
                    OnCoordChanged?.Invoke(this);
                }
            }
        }
    }
    class Program
    {
        static void PrintInfo(Dot A)
        {
            Console.WriteLine($"Абцисса: {A.X}\nОрдината: {A.Y}");
        }
        static void Main(string[] args)
        {
            double x;
            double y;
            Console.WriteLine("Введите значение абциссы: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Введите корректное значение абциссы: ");
            }
            Console.WriteLine("Введите значение ординаты: ");
            while (!double.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Введите корректное значение ординаты: ");
            }
            Dot D = new(x, y);
            D.OnCoordChanged += PrintInfo;
            D.DotFlow();
        }
    }
}
