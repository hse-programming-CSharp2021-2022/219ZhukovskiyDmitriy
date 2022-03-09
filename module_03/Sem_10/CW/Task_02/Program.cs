using System;

namespace Task_02
{
    class Queue<T>
        where T : struct
    {
        public int Size { get; set; }
        public Node<T> FirstNode { get; set; }
        public Node<T> LastNode { get; set; }
        public bool IsEmpty() => FirstNode is null;

        public Queue()
        {
            Size = 0;
            FirstNode = null;
            LastNode = null;
        }

        public T Dequeue()
        {
            if (FirstNode is null)
            {
                throw new NullReferenceException("There are no items in the queue!");
            }

            T value = FirstNode.Item;
            FirstNode = FirstNode.Next;
            if (FirstNode == null)
            {
                LastNode = null;
            }
            Size--;

            return value;
        }

        public void Enqueue(T item)
        {
            var tmp = new Node<T>(item);
            Size++;

            FirstNode ??= tmp;
            if (LastNode is null)
            {
                LastNode = tmp;
            }
            else
            {
                LastNode.Next = tmp;
                LastNode = tmp;
            }
        }

        public T Top()
        {
            if (FirstNode is null)
            {
                throw new NullReferenceException("There are no items in the queue!");
            }

            return FirstNode.Item;
        }
    }

    class Node<T>
    {
        public T Item { get; }
        public Node<T> Next { get; set; }

        public Node(T item, Node<T> next = null)
        {
            Item = item;
            Next = next;
        }
    }
    struct Person
    {
        public string Name { get; }
        public string Lastname { get; }
        public int Age { get; }

        public Person(string name, string lastname, int age) => (Name, Lastname, Age) = (name, lastname, age);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Queue<Person> people = new();
            people.Enqueue(new Person("Ivan", "Ivanov", 20));
            people.Enqueue(new Person("Peter", "Petrov", 25));
            Console.WriteLine(people.Top().Name);
            Console.WriteLine(people.IsEmpty());
            people.Dequeue();
            Console.WriteLine(people.Top().Name);
            Console.WriteLine(people.Size);
        }
    }
}