using System;

namespace Task01
{
    class Program
    {
        public static bool F1(bool p, bool q)
        {
            return !(p && q) && (!(p | !q));
        }

        public static void F2(out bool a, bool p, bool q)
        {
            a = !(p && q) && (!(p | !q));
        }

        static void Main()
        {
            bool a;
            Console.WriteLine(F1(true, true));
            Console.WriteLine(F1(false, false));
            Console.WriteLine(F1(true, false));
            Console.WriteLine(F1(false, true));
            F2(out a, true, true);
            Console.WriteLine(a);
            F2(out a, false, false);
            Console.WriteLine(a);
            F2(out a, true, false);
            Console.WriteLine(a);
            F2(out a, false, true);
            Console.WriteLine(a);
 
        }
    }
}

