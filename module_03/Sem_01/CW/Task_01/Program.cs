using System;

namespace Task_01
{
    class A
    {
        public void MyMethodA()
        {
            Console.WriteLine(1);
        }
    }
    class Program
    {
        public static void MyMethod()
        {
            Console.WriteLine(1);
        }
        public void MyMethodNonStatic()
        {
            Console.WriteLine(1);
        }
        public delegate void MyDel();
        static void Main()
        {
            MyDel myDel = new MyDel(MyMethod);
            A a = new A();
            MyDel myDel2 = a.MyMethodA;
            MyDel myDel3 = new Program().MyMethodNonStatic;
            MyDel myDel4 = delegate {
                Console.WriteLine(2);
            }; ;
            MyDel myDel5 = () => Console.WriteLine(3);
            myDel();  // 1
            myDel2(); // 1
            myDel4(); // 2
            myDel5(); // 3
            Console.WriteLine(myDel.Method); // void MyMethod()
            Console.WriteLine(myDel.Target); // null
            Console.WriteLine(myDel2.Method); // void MyMethodA()
            Console.WriteLine(myDel2.Target); // A
            Console.WriteLine(myDel4.Method); // Void <Main>b__3_0()
            Console.WriteLine(myDel4.Target); // Program +<> c
            Console.WriteLine(myDel5.Method); // Void <Main>b__3_1()
            Console.WriteLine(myDel5.Target); // Program +<> c
        }
    }
}
