using System;
using System.Collections.Generic;
namespace Task01
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double _x = 0, double _y = 0)
        {
            X = _x;
            Y = _y;
        }
        public static double Distance(Point p1, Point p2)
        {
            return p1.Distance(p2);
        }
        public double Distance(Point p)
        {
            return Math.Sqrt((X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y));
        }
    }
    class TriangleComp : IComparable<TriangleComp>
    {
        public Point A, B, C;
        public double AB, AC, BC;
        private double area = -1;
        public double Area
        {
            get
            {
                if (area == -1)
                {
                    double p = (AB + AC + BC) / 2;
                    return area = Math.Sqrt(p * (p - AB) * (p - AC) * (p - BC));
                }
                return area;
            }
        }
        public TriangleComp(Point _A, Point _B, Point _C)
        {
            A = _A;
            B = _B;
            C = _C;
            AB = A.Distance(B);
            AC = A.Distance(C);
            BC = B.Distance(C);
        }
        private double Sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }
        public bool PointInTriangle(Point pt)
        {
            double d1, d2, d3;
            bool isNegative, isPositive;
            d1 = Sign(pt, A, B);
            d2 = Sign(pt, B, C);
            d3 = Sign(pt, C, A);
            isNegative = (d1 < 0) || (d2 < 0) || (d3 < 0);
            isPositive = (d1 > 0) || (d2 > 0) || (d3 > 0);
            return !(isNegative && isPositive);
        }
        public int CompareTo(TriangleComp obj)
        {
            return this.Area.CompareTo(obj.Area);
        }
    }
    class TriangleCompComparer : IComparer<TriangleComp>
    {
        public int Compare(TriangleComp X, TriangleComp Y)
        {
            double x = X.AB + X.AC + X.BC;
            double y = Y.AB + Y.AC + Y.BC;
            return y.CompareTo(x);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TriangleComp tc = new(new Point(0, 0), new Point(0, 1), new Point(1, 0));
            Console.WriteLine(tc.Area + " " + tc.PointInTriangle(new Point(0.1, 0.1)));
            int n = 5;
            TriangleComp[] triangleComps = new TriangleComp[n];
            triangleComps[0] = new(new Point(0, 0), new Point(0, 1), new Point(1, 0));
            triangleComps[1] = new(new Point(1, 0), new Point(6, 1), new Point(1, 9));
            triangleComps[2] = new(new Point(1, 2), new Point(0, 1), new Point(5, 9));
            triangleComps[3] = new(new Point(-1, 3), new Point(0, 1), new Point(1, 10));
            triangleComps[4] = new(new Point(7, 6), new Point(7, 1), new Point(1, 0));
            Array.Sort(triangleComps);
            foreach (var a in triangleComps)
                Console.WriteLine(a.Area);
            Console.WriteLine("***");
            Array.Sort(triangleComps, new TriangleCompComparer());
            foreach (var a in triangleComps)
                Console.WriteLine(a.Area);
            Console.WriteLine("***");
        }
    }
}