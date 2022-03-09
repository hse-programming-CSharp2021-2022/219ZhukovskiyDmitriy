using System;

namespace Task_01
{
    class Stack<T>
    {
        public int Size { get; private set; }

        public Node<T> LastNode { get; private set; }

        public Stack()
        {
            Size = 0;
            LastNode = null;
        }

        public void Push(T item)
        {
            LastNode = new(item, LastNode);
            Size++;
        }

        public T Pop()
        {
            T item = LastNode.Item;
            LastNode = LastNode.Previous;
            Size--;
            return item;
        }

        public T Peek() => LastNode.Item;

        public bool IsEmpty() => Size == 0;
    }

    class Node<T>
    {
        public T Item { get; }
        public Node<T> Previous { get; }

        public Node(T item, Node<T> previous)
        {
            Item = item;
            Previous = previous;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(15);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());

            Console.WriteLine("— — — — — — —");

            Console.WriteLine($"Size: {stack.Size}");
            Console.WriteLine($"Stack status: {stack.IsEmpty()}");
        }
    }
}