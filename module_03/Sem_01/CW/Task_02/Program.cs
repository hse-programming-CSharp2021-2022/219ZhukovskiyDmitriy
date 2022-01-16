using System;

namespace Task_02
{
    class A
    {
        public int MyMethodA(ref int a)
        {
            Console.WriteLine(a);
            a += 1;
            return a;
        }
    }
    class Program
    {
        public static int MyMethod(ref int a)
        {
            Console.WriteLine(a);
            a += 1;
            return a;
        }
        public int MyMethodNonStatic(ref int a)
        {
            Console.WriteLine(a);
            a += 1;
            return a;
        }
        public delegate int MyDel(ref int a);
        static void Main()
        {
            MyDel myDel = new MyDel(MyMethod);
            A a = new A();
            MyDel myDel2 = a.MyMethodA;
            MyDel myDel3 = new Program().MyMethodNonStatic;
            MyDel myDel4 = delegate (ref int a) {
                Console.WriteLine(a);
                a += 1;
                return a;
            }; ;
            MyDel myDel5 = (ref int a) =>
            {
                Console.WriteLine(a);
                a += 1;
                return a;
            };
            int x = 1;
            MyDel myDel6 = myDel + myDel2 + myDel3 + myDel4 + myDel5;
            Console.WriteLine(myDel6(ref x)); //12345->6
        }
    }
}
