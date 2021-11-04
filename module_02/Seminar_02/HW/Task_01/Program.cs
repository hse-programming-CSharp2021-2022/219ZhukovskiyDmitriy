using System;

namespace Task_01
{
    class MyComplex
    {
        private double re, im;
        public double Re { get { return re; } set { re = value; } }
        public double Im { get { return im; } set { im = value; } }
        public MyComplex(double xre, double xim)
        {
            Re = xre;
            Im = xim;
        }
        public static MyComplex operator ++(MyComplex mc)
        {
            return new MyComplex(mc.re + 1, mc.im + 1);
        }
        public static MyComplex operator --(MyComplex mc)
        {
            return new MyComplex(mc.re - 1, mc.im - 1);
        }
        public double Mod()
        {
            return Math.Abs(re * re + im * im);
        }

        static public bool operator true(MyComplex f)
        {
            if (f.Mod() > 1.0) return true;
            return false;
        }

        static public bool operator false(MyComplex f)
        {
            if (f.Mod() <= 1.0) return true;
            return false;
        }
        public static MyComplex operator +(MyComplex mc1, MyComplex mc2)
        {
            return new MyComplex(mc1.re + mc2.re, mc1.im + mc2.im);
        }
        public static MyComplex operator -(MyComplex mc1, MyComplex mc2)
        {
            return new MyComplex(mc1.re - mc2.re, mc1.im - mc2.im);
        }
        public static MyComplex operator *(MyComplex mc1, MyComplex mc2)
        {
            return new MyComplex(mc1.re * mc2.re - mc1.im * mc2.im, mc1.im * mc2.re + mc1.re * mc2.im);
        }
        public static MyComplex operator /(MyComplex mc1, MyComplex mc2)
        {
            double a = mc1.re;
            double b = mc1.im;
            double c = mc2.re;
            double d = mc2.im;
            return new MyComplex((a * c + b * d) / (c * c + d * d), (b * c - a * d) / (c * c + d * d));
        }
        public override string ToString()
        {
            if (im < 0)
            {
                return $"{re} - {Math.Abs(im)}i";
            }
            return $"{re} + {im}i";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyComplex complex1 = new MyComplex(3, 5);
            MyComplex complex2 = new MyComplex(10, 8);
            Console.WriteLine(complex1 + complex2);
            Console.WriteLine(complex1 - complex2);
            Console.WriteLine(complex1 * complex2);
            Console.WriteLine(complex1 / complex2);
            Console.WriteLine("Модуль: " + complex1.Mod());
        }
    }
}
