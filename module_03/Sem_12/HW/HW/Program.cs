using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;

namespace HW
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }

        public Human()
        {

        }
        public Human(string name)
        {
            Name = name;
        }
    }

    [Serializable]
    class Professor : Human
    {
        public Professor(string name) : base(name)
        { }

        public Professor()
        {

        }
    }

    [Serializable]
    public class Department
    {
        public List<Human> Humans { get; set; }

        public Department()
        {
            Random rnd = new Random();
            int numOfHumans = rnd.Next(10, 100);
            List<Human> humans = new List<Human>();
            for (int i = 0; i < numOfHumans; i++)
            {
                var human = new Human($"{Convert.ToChar(rnd.Next(65, 91))}" +
                                      $"{Convert.ToChar(rnd.Next(97, 123))}" +
                                      $"{Convert.ToChar(rnd.Next(97, 123))}" +
                                      $"{Convert.ToChar(rnd.Next(97, 123))}");
                humans.Add(human);
            }
            Humans = humans;
        }

        public override string ToString()
        {
            string ans = "Department: ";
            foreach (var human in Humans)
            {
                ans += $"{human.Name}, ";
            }

            return ans[..^2];
        }
    }

    [Serializable]
    public class University
    {
        public List<Department> Departments { get; set; }

        public University()
        {
        }
        public University(List<Department> departments)
        {
            Departments = departments;
        }

        public override string ToString()
        {
            string ans = "\nUniversity:";
            foreach (var department in Departments)
            {
                ans += $"\n{department}";
            }
            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<University> universities = new List<University>();

            for (int i = 0; i < 2; i++)
            {
                List<Department> departments = new List<Department>();
                for (int j = 0; j < 3; j++)
                {
                    departments.Add(new Department());
                }
                universities.Add(new University(departments));
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("binary.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, universities);
            }

            using (FileStream file = new FileStream("binary.txt", FileMode.OpenOrCreate))
            {
                List<University> binuUniversities = (List<University>)formatter.Deserialize(file);
                Console.WriteLine("Бинарная сериализация");
                foreach (var uni in binuUniversities)
                {
                    Console.WriteLine(uni);
                }
                Console.WriteLine("------------------------------");
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<University>));
            using (FileStream file = new FileStream("XML.txt", FileMode.Create))
            {
                xmlSerializer.Serialize(file, universities);
            }

            using (FileStream file = new FileStream("XML.txt", FileMode.Open))
            {
                var xmlUniversities = (List<University>)xmlSerializer.Deserialize(file);
                Console.WriteLine("XML-сериализация");
                foreach (var uni in xmlUniversities)
                {
                    Console.WriteLine(uni);
                }
                Console.WriteLine("------------------------------");
            }

            var jsonUniversity = JsonSerializer.Serialize(universities);
            var university = JsonSerializer.Deserialize<List<University>>(jsonUniversity);
            Console.WriteLine("JSON-сериализация");
            foreach (var item in university)
            {
                Console.WriteLine(item);
            }
        }
    }
}
