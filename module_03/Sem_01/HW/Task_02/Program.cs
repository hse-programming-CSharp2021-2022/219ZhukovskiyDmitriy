using System;

namespace Task_02
{
    class TemparatureConverterImp
    {
        public double ConvertToCelsius(double fahr)
        {
            Console.WriteLine("Перевод из Фарангейтов в Цельсий:");
            double cels = 5.0 / 9.0 * (fahr - 32.0);
            return cels;
        }
        public double ConvertToFahrenheit(double cels)
        {
            Console.WriteLine("Перевод из Цельсия в Фарангейты:");
            double fahr = 9.0 / 5.0 * cels + 32.0;
            return fahr;
        }
    }
    class StaticTempConverts
    {
        public static double ConvertToKelvin(double cels)
        {
            Console.WriteLine("Перевод из Цельсий в Кельвины:");
            double kel = cels + 273.15;
            return kel;
        }
        public static double ConvertToCelsiusFromKel(double kel)
        {
            Console.WriteLine("Перевод из Кельвинов в Цельсий:");
            double cels = kel - 273.15;
            return cels;
        }
        public static double ConvertToRankin(double cels)
        {
            Console.WriteLine("Перевод из Цельсий в Ранкины:");
            double rankin = (cels + 273.15) * 9.0 / 5.0;
            return rankin;
        }
        public static double ConvertToCelsiusFromRankin(double rankin)
        {
            Console.WriteLine("Перевод из Ранкинов в Цельсий:");
            double cels = (rankin - 491.67) * 5.0 / 9.0;
            return cels;
        }
        public static double ConvertToReaumur(double cels)
        {
            Console.WriteLine("Перевод из Цельсий в Реомюры:");
            double reaum = cels * 4.0 / 5.0;
            return reaum;
        }
        public static double ConvertToCelsiusFromReaumur(double reaum)
        {
            Console.WriteLine("Перевод из Реомюров в Цельсий:");
            double cels = reaum * 5.0 / 4.0;
            return cels;
        }
    }
    class Program
    {
        delegate double DelegateConvertTemperature(double t);
        static void Main(string[] args)
        {
            TemparatureConverterImp temparature = new();
            // Первая часть задания
            DelegateConvertTemperature conv1 = temparature.ConvertToCelsius;
            DelegateConvertTemperature conv2 = temparature.ConvertToFahrenheit;
            Console.WriteLine(conv1(33)+"\n");
            Console.WriteLine(conv2(57) + "\n");
            
            // Вторая часть задания
            conv1 += StaticTempConverts.ConvertToCelsiusFromKel;
            conv1 += StaticTempConverts.ConvertToCelsiusFromRankin;
            conv1 += StaticTempConverts.ConvertToCelsiusFromReaumur;

            conv2 += StaticTempConverts.ConvertToKelvin;
            conv2 += StaticTempConverts.ConvertToRankin;
            conv2 += StaticTempConverts.ConvertToReaumur;

            DelegateConvertTemperature convAll = conv1 + conv2;
            Delegate[] delegates = convAll.GetInvocationList();
            for (int i = 0;i<delegates.Length;i++)
            {
                Console.WriteLine(((DelegateConvertTemperature)delegates[i])?.Invoke(60)+"\n");
            }


        }
    }
}
