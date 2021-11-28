using System;
using System.Collections.Generic;
//Задача с 40 слайда 2_03a
namespace Cinderella
{
    abstract class Something
    {

    }
    class Lentil : Something
    {

        double Weight;
        public Lentil()
        {
            Random random = new();
            Weight = random.NextDouble()*2;
            
        }
        public override string ToString()
        {
            return $"This is Lentil. Weight: {Weight}.";
        }
    }
    class Ashes : Something
    {
        double Volume;
        public Ashes()
        {
            Random random = new();
            Volume = random.NextDouble();
        }
        public override string ToString()
        {
            return $"This is Ashes. Volume: {Volume}.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Lentil> lentils = new();
            List<Ashes> ashes = new();
            Random random = new();
            int N;
            Console.Write("Введите число от 5 до 10: ");
            while(!int.TryParse(Console.ReadLine(),out N)|| N <5 || N>10)
            {
                Console.Write("Введите число от 5 до 10: ");
            }
            Something[] some = new Something[N];
            for (int i = 0; i < some.Length; i++)
            {
                int x = random.Next(0, 2);
                if (x==0)
                {
                    Lentil lentil = new();
                    some[i] = lentil;
                    lentils.Add(lentil);
                }
                if (x == 1)
                {
                    Ashes ash = new();
                    some[i] = ash;
                    ashes.Add(ash);
                }
                Console.WriteLine(some[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Lentils list:");
            for (int i = 0; i < lentils.Count; i++)
            {
                Console.WriteLine(lentils[i]);
            }
            if (lentils.Count == 0)
                Console.WriteLine("Lentil is empty!");
            Console.WriteLine();
            Console.WriteLine("Ashes list:");
            for (int i = 0; i < ashes.Count; i++)
            {
                Console.WriteLine(ashes[i]);
            }
            if (ashes.Count == 0)
                Console.WriteLine("Ashes is empty!");
        }
    }
}


