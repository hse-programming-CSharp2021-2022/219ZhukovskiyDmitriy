using System;
using System.Text;

namespace HW
{
    struct Person:IComparable<Person>
    {
        private string name;
        private string lastname;
        private int age;
        public Person(string name, string lastname,int age)
        {
            this.name = name;
            this.lastname = lastname;
            this.age = age;
            if (this.age < 0)
            {
                throw new ArgumentOutOfRangeException("Возраст не может быть меньше нуля!");
            }
        }

        public int CompareTo(Person other)
        {
            return this.age - other.age;
        }

        public override string ToString()
        {
            return $"Имя, фамилия: {name} {lastname}. Возраст: {age}";
        }
    }
    internal class Program
    {
        static Random random = new Random();
        static string GenerateNameOrLastname()
        {
            
            StringBuilder name = new();
            for (int i = 0; i < 5; i++)
            {
                name.Append((char)random.Next(65, 91));
            }
            return name.ToString();
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] characters = new Person[n];
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = new Person(GenerateNameOrLastname(), GenerateNameOrLastname(), random.Next(1, 101));
                Console.WriteLine(characters[i]);
            }
            Console.WriteLine("\nПосле сортировки\n");
            Array.Sort(characters);
            foreach (var item in characters)
            {
                Console.WriteLine(item);
            }
        }
    }
}
