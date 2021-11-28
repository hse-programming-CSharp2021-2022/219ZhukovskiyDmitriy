using System;
using System.Text;
using System.Collections.Generic;
namespace HW
{
    class Creature
    { 
        public string Name { get; set; }
        public double Speed { get; set; }
        public Creature(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }
        public virtual string Run()
        {
            return $"I am running with a speed of {Speed}.";
        }
        public override string ToString()
        {
            return $"{Run()} My name is {Name}.";
        }
    }
    class Dwarf : Creature
    {
        Random random = new();
        int strength;
        public int Strength
        {
            get
            {
                return strength;
            }
            set
            {
                strength = value;
                if (strength <1 || strength >20)
                {
                    strength = random.Next(1, 21);
                }
            }
        }
        public Dwarf(string name, double speed, int strength) : base(name,speed)
        {
            Name = name;
            Speed = speed;
            Strength = strength;
        }
        public string MakeNewStaff()
        {
            return "I've created a new staff!";
        }
        public override string Run()
        {
            return $"{base.Run()} My strength is {Strength}.";
        }
    }
    class Elf : Creature
    {
        Random random = new();
        int age;
        public Elf(string name, double speed):base(name,speed)
        {
            Name = name;
            Speed = speed;
            age = random.Next(100, 201);
        }
        public override string Run()
        {
            return $"I am running with speed of {Speed + age / 77}. My age is {age}.";
        }
    }


    class Program
    {
        
        public static string CreateRandomName(Random random)
        {
            int nameLength = random.Next(3, 11);
            StringBuilder name = new();
            char firstLetter = (char)random.Next('A', 'Z' + 1);
            name.Append(firstLetter);
            for (int i = 1;i<nameLength;i++)
            {
                char one = (char)random.Next('A', 'Z' + 1);
                char two = (char)random.Next('a', 'z' + 1);
                int choice = random.Next(0, 2);
                if (choice == 0)
                {
                    name.Append(one);
                }
                if (choice == 1)
                {
                    name.Append(two);
                }

            }
            return name.ToString();
        }
        static void Main(string[] args)
        {
            
            do
            {
                Console.Clear();
                Random random = new();
                int n;
                Console.Write("Введите число в промежутке от 1 до 100: ");
                while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 100)
                {
                    Console.Write("Введите число в промежутке от 1 до 100: ");
                }
                Creature[] creatures = new Creature[n];
                List<Dwarf> dwarves = new();
                for (int i = 0; i < n; i++)
                {
                    int choice = random.Next(0, 10);
                    if (choice == 0 || choice == 1)
                    {
                        Creature creature = new(CreateRandomName(random), random.Next(10, 19));
                        creatures[i] = creature;
                    }
                    if (choice > 1 && choice < 6)
                    {
                        Dwarf dwarf = new(CreateRandomName(random), random.Next(10, 19), random.Next(-50, 51));
                        creatures[i] = dwarf;
                        dwarves.Add(dwarf);
                    }
                    if (choice > 5 && choice < 10)
                    {
                        Elf elf = new(CreateRandomName(random), random.Next(10, 19));
                        creatures[i] = elf;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(creatures[i]);
                }

                for (int i = 0; i < dwarves.Count; i++)
                {
                    Console.WriteLine(dwarves[i].MakeNewStaff());
                }
                Console.WriteLine();
                Console.WriteLine("Нажмите ESC для завершения программы.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
