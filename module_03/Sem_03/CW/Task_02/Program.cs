using System;

namespace Task_02
{
    public delegate void SquareSizedChanged(double x);
    public class SquareEventArgs : EventArgs
    {
        public double Side { get; }
        public SquareEventArgs(double side) => Side = side;
    }
    class Square
    {
        private double x1, y1, x2, y2;
        public event EventHandler<SquareEventArgs> OnSizeChanged;
        public Square(double x1, double x2, double y1, double y2)
            => (this.x1, this.x2, this.y1, this.y2) = (x1, x2, y1, y2);
        public double X1
        {
            get => x1;
            set
            {
                x1 = value;
                OnSizeChanged?.Invoke(this, new SquareEventArgs(Math.Abs(x2 - x1)));
            }
        }
        public double Y1
        {
            get => y1;
            set
            {
                y1 = value;
                OnSizeChanged?.Invoke(this, new SquareEventArgs(Math.Abs(y2 - y1)));
            }
        }
        public double X2
        {
            get => x2;
            set
            {
                x2 = value;
                OnSizeChanged?.Invoke(this, new SquareEventArgs(Math.Abs(x2 - x1)));
            }
        }
        public double Y2
        {
            get => y2;
            set
            {
                y2 = value;
                OnSizeChanged?.Invoke(this, new SquareEventArgs(Math.Abs(y2 - y1)));
            }
        }
    }
    class Program
    {
        private static void SquareConsoleInfo(object s, SquareEventArgs x)
            => Console.WriteLine($"{x.Side:f3}");
        static void Main(string[] args)
        {
            var x1 = 0;
            var x2 = 10;
            var y1 = 0;
            var y2 = 10;
            var S = new Square(x1, x2, y1, y2);
            S.OnSizeChanged += SquareConsoleInfo;
            var input = "";
            while (input != "*")
            {
                input = Console.ReadLine();
                x2 = int.Parse(input);
                input = Console.ReadLine();
                y2 = int.Parse(input);
                S.X2 = x2;
                S.Y2 = y2;
            }
        }
    }
}

