using System;
using System.Collections.Generic;
using System.Linq;
namespace Task_02
{
    abstract class Animal : IComparable<Animal>
    {
        public uint Age { get; protected set; }
        public int CompareTo(Animal other)
        {
            if (Age < other.Age) return 1;
            if (Age > other.Age) return -1;
            return 0;
        }
    }
    interface IJump
    {
        void Jump();
    }
    interface IRun
    {
        void Run();
    }
    class Cockroach : Animal, IRun
    {
        public Cockroach(uint age, uint speed)
        {
            Speed = speed;
            Age = age;
        }
        public void Run()
        {
            Console.WriteLine($"Cockroach running, speed = {Speed}, age = {Age}.");
        }
        public uint Speed { get; }
    }
    class CockroachComparer : IComparer<Cockroach>
    {
        public int Compare(Cockroach lhs, Cockroach rhs)
        {
            if (lhs.Speed < rhs.Speed) return 1;
            if (lhs.Speed > rhs.Speed) return -1;
            return 0;
        }
    }
    class Kangaroo : Animal, IJump
    {
        public Kangaroo(uint age, uint height)
        {
            Height = height;
            Age = age;
        }
        public void Jump()
        {
            Console.WriteLine($"Kangaroo jumping, height = {Height}, age = {Age}.");
        }
        public uint Height { get; }
    }
    class KangarooComparer : IComparer<Kangaroo>
    {
        public int Compare(Kangaroo lhs, Kangaroo rhs)
        {
            if (lhs.Height < rhs.Height) return 1;
            if (lhs.Height > rhs.Height) return -1;
            return 0;
        }
    }
    class Cheetah : Animal, IJump, IRun
    {
        public Cheetah(uint age, uint speed, uint height)
        {
            Height = height;
            Age = age;
            Speed = speed;
        }
        public void Jump()
        {
            Console.WriteLine($"Cheetah jumping, height = {Height}, age = {Age}.");
        }
        public void Run()
        {
            Console.WriteLine($"Cheetah running, speed = {Speed}, age = {Age}.");
        }
        public uint Height { get; }
        public uint Speed { get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> arr = new List<Animal>()
        {
            new Cheetah(12, 13, 14),
            new Cheetah(15, 16, 17),
            new Cockroach(18, 19),
            new Cockroach(16, 25),
            new Cockroach(17, 35),
            new Kangaroo(20, 21),
            new Kangaroo(25, 55)
        };
            arr.Sort();
            foreach (var animal in arr)
            {
                Console.WriteLine($"{animal.GetType().Name}, age = {animal.Age}");
            }
            Console.WriteLine("--------");
            List<Cockroach> cockroaches = new List<Cockroach>();
            foreach (var animal in arr)
            {
                if (animal is Cockroach) cockroaches.Add(animal as Cockroach);
            }
            cockroaches.Sort(new CockroachComparer());
            foreach (var cockroach in cockroaches)
            {
                Console.WriteLine($"Cockroach, age = {cockroach.Age}, speed = {cockroach.Speed}");
            }
            Console.WriteLine("--------");
            List<Kangaroo> kangaroos = new List<Kangaroo>();
            foreach (var animal in arr)
            {
                if (animal is Kangaroo) kangaroos.Add(animal as Kangaroo);
            }
            kangaroos.Sort(new KangarooComparer());
            foreach (var kangaroo in kangaroos)
            {
                Console.WriteLine($"Kangaroo, age = {kangaroo.Age}, height = {kangaroo.Height}");
            }
        }
    }
}