using System;
using System.Collections;

namespace CW
{
    class Fibbonacci : IEnumerable
    {
        private int _current = 0;
        private int _next = 1;

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < 10; i++)
            {
                yield return _next;
                (_current, _next) = (_next, _current + _next);
            }
        }

        public IEnumerable Enumerable(int n)
        {
            for (var i = 0; i < n; i++)
            {
                yield return _next;
                (_current, _next) = (_next, _current + _next);
            }
        }
    }

    class Fibbonacci1 : IEnumerable, IEnumerator
    {
        public IEnumerator GetEnumerator() => this;

        private int _current = 0;
        private int _next = 1;
        private int _n;
        private int _position = -1;

        public Fibbonacci1(int n) => _n = n;

        public bool MoveNext()
        {
            if (_current < _n - 1)
            {
                (_current, _next) = (_next, _current + _next);
                _position++;
                return true;
            }

            Reset();
            return false;
        }

        public void Reset() => (_current, _next, _position) = (0, 1, -1);

        public object Current => _current;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var fibbonacci1 = new Fibbonacci();
            foreach (var digit in fibbonacci1)
            {
                Console.Write($"{digit} ");
            }

            Console.WriteLine();

            var fibbonacci2 = new Fibbonacci();
            foreach (var digit in fibbonacci2.Enumerable(10))
            {
                Console.Write($"{digit} ");
            }

            Console.WriteLine();

            var fibbonacci3 = new Fibbonacci1(10);
            foreach (var digit in fibbonacci3)
            {
                Console.Write($"{digit} ");
            }
        }
    }
}
