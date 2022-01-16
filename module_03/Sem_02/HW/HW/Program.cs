using System;

namespace HW
{
    class Plant
    {
        int growth;
        int photosensivity;
        int frostresistance;
        public int Growth
        {
            get
            {
                return growth;
            }
            set
            {
                growth = value;
            }
        }
        public int Photosensivity
        {
            get
            {
                return photosensivity;
            }
            set
            {
                photosensivity = value;
            }
        }
        public int Frostresistance
        {
            get
            {
                return frostresistance;
            }
            set
            {
                frostresistance = value;
            }
        }
        public Plant(int growth, int photosensivity, int frostresistance)
        {
            Growth = growth;
            Photosensivity = photosensivity;
            Frostresistance = frostresistance;
        }
        public override string ToString()
        {
            return $"Рост: {Growth}" + "\n" + $"Светочувствительность: {Photosensivity}" + "\n" + $"Морозоустойчивость: {Frostresistance}" +"\n";
        }
    }
    class Program
    {
        public static int Change(Plant x, Plant y)
        {
            return x.Photosensivity % 2 == y.Photosensivity % 2 ? 0 : x.Photosensivity % 2 > y.Photosensivity % 2 ? 1 : -1;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите число растений: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Plant[] plants = new Plant[n];
            Random random = new();
            for (int i = 0; i < n; i++)
            {
                plants[i] = new(random.Next(25, 101), random.Next(101), random.Next(81));                
            }
            Console.WriteLine("Изначальный список: "+"\n");
            Array.ForEach(plants, val => Console.WriteLine($"{val}"));
            Array.Sort(plants, delegate(Plant x,Plant y)
            {
                return x.Growth == y.Growth ? 0 : x.Growth > y.Growth ? -1 : 1;
            });
            Console.WriteLine("Отсортирован по росту: " + "\n");
            Array.ForEach(plants, val => Console.WriteLine($"{val}"));
            Array.Sort(plants, (x, y) =>
            {
                return x.Frostresistance == y.Frostresistance ? 0 : x.Frostresistance > y.Frostresistance ? 1 : -1;
            });
            Console.WriteLine("Отсортирован по морозоустойчивости: " + "\n");
            Array.ForEach(plants, val => Console.WriteLine($"{val}"));
            Array.Sort(plants, Change);
            Console.WriteLine("Отсортирован по четности светочувствительности: " + "\n");
            Array.ForEach(plants, val => Console.WriteLine($"{val}"));
            Array.ConvertAll(plants, x =>
            {
                return x.Frostresistance = x.Frostresistance % 2 == 0 ? x.Frostresistance / 3 : x.Frostresistance / 2;
            });
            Console.WriteLine("Изменена морозоустойчивость: " + "\n");
            Array.ForEach(plants, val => Console.WriteLine($"{val}"));
        }
    }
}
