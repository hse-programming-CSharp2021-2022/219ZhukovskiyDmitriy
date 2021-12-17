using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HW
{
    abstract class Person
    {
        public static Random random = new Random();
        public string Name { get; set; }
        public string Pocket { get; set; }
        public abstract void Receive(string present);
        public Person(string name)
        {
            Name = name;
            Pocket = string.Empty;
        }
        public override string ToString()
        {
            return $"Name = {Name} Pocket = {Pocket} ";
        }
    }
    class SnowMaiden : Person
    {
        public SnowMaiden(string name) : base(name) { }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException("Подарок уже был получен!");
        }
        private string CreateString()
        {
            int n = random.Next(4, 11);
            StringBuilder sb = new StringBuilder(n);
            for (int i = 0; i < n; i++)
                sb.Append((char)random.Next('a', 'z' + 1));
            return sb.ToString();
        }
        public string[] CreatePresents(int amount)
        {
            string[] gifts = new string[amount];
            for (int i = 0; i < amount; i++)
                gifts[i] = CreateString();
            return gifts;
        }
    }
    class Santa : Person
    {
        List<string> sack;
        public void Request(SnowMaiden snowMaiden, int amount)
        {
            sack.AddRange(snowMaiden.CreatePresents(amount));
        }
        public Santa(string name) : base(name)
        {
            sack = new List<string>();
        }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException("уже получил подарок!");
        }
        public void Give(Person person)
        {
            int n = random.Next(0, sack.Count);
            if (sack.Count > 0)
            {
                person.Receive(sack[n]);
                sack.RemoveAt(n);
            }
            else
            {
                throw new Exception("В мешке закончились подарки!");
            }
        }
    }
    class Child : Person
    {
        public string AdditionalPocket { get; set; }
        public Child(string name) : base(name)
        {
            AdditionalPocket = string.Empty;
        }
        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else if (AdditionalPocket.Equals(string.Empty))
                AdditionalPocket = present;
            else
                throw new ArgumentException("2 подарка уже были получены!");
        }
        public override string ToString()
        {
            return $"Name = {Name} Pocket = {Pocket} Pocket2 = {AdditionalPocket}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Santa santa = new Santa("Santa");
                SnowMaiden snowMaiden = new SnowMaiden("SnowMaiden");
                int n = 10;
                List<Person> people = new();
                people.Add(santa);
                people.Add(snowMaiden);
                for (int i = 2; i < n + 2; i++)
                {
                    Child child = new Child(i.ToString());
                    people.Add(child);
                }
                for (int i = 0; i < n + 2; i++)
                    Console.WriteLine(people[i].ToString());
                Console.WriteLine("\nНачинаем вручение подарков!\n");
                Random random = new Random();

                while (true)
                {
                    int rememberHuman = -1;
                    int number = random.Next(0, 10);
                    if (people[1] == snowMaiden)
                    {
                        santa.Request(snowMaiden, random.Next(1, 5));
                    }
                    try
                    {
                        if (number == 0)
                        {
                            santa.Give(people[number]);
                            Console.WriteLine($"{people[number].ToString()} получил подарок!");
                        }
                        else
                        {
                            int humanPosition = random.Next(1, people.Count);
                            rememberHuman = humanPosition;
                            santa.Give(people[humanPosition]);
                            Console.WriteLine($"{people[humanPosition].ToString()} получил подарок!");
                        }

                    }
                    catch (ArgumentException e)
                    {
                        if (number == 0)
                        {
                            Console.WriteLine("\nСанта " + e.Message);
                            people.RemoveAt(number);
                            Console.WriteLine("Санта изгнан.");
                            Console.WriteLine("Нажмите ESC для завершения работы программы.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{people[rememberHuman]}" + ". " + e.Message + " Выгнан из круга.");
                            people.RemoveAt(rememberHuman);
                            if (people.Count == 1)
                            {
                                Console.WriteLine("\nОстался один Санта.");
                                Console.WriteLine("Нажмите ESC для завершения программы.");
                                break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n"+e.Message);
                        Console.WriteLine("Нажмите ESC для завершения программы.");
                        break;
                    }
                }
                
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
