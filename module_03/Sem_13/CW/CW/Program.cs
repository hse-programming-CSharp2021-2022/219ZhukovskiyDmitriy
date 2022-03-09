using System;
using System.Collections;

namespace CW
{
    class Fibonacci:IEnumerable
    {
        int s = 1, n = 0;

        public IEnumerator GetEnumerator()
        {
            int t;
            for (int i = 0; i < 10; i++)
            {
                t = s + n;
                s = n;
                yield return n = t;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fibonacci = new Fibonacci();
            foreach (var item in fibonacci)
            {
                Console.WriteLine(item);
            }
        }
    }
}
