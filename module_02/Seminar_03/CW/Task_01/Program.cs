using System;

namespace Task_01
{
    class ArifmProgress
    {
        public int A0 { get;private set; }
        public int D0 { get; private set; }
        public static int count = 0;
        static ArifmProgress()
        {
            Console.WriteLine("Create static field");   
        }
        public ArifmProgress(int a0,int d)
        {
            A0 = a0;
            D0 = d;
            count++;
        }
        public ArifmProgress() : this(0, 0) { }
        public int this[int index]
        {
            get
            {
                return A0 + D0 * (index);
            }
            private set
            {

            }
        }
        ~ArifmProgress()
        {
            Console.WriteLine("Destroy object");
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            ArifmProgress progress = new ArifmProgress(2, 10);
            Console.WriteLine(progress[3]);
            Console.WriteLine(progress[5]);
            Console.WriteLine(ArifmProgress.count);
        }
    }
}
