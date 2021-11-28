using System;
using System.IO;
namespace Exceptions
{
    class HSEException : Exception
    { 
        public HSEException(string message):base(message)
        {
            
        }
    }
    class Marks
    {
        public int Mark { get; set; }
        public Marks(int mark)
        {
            if (mark!=10)
            {
                throw new HSEException("Как оценка не 10? Почему?");
            }
            Mark = mark;
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 ex: ");
            int x = 5;
            try
            {
                int y = x / 0;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("2 ex: ");
            int[] mas = { 2, 3, 4 };
            try
            {
                Console.WriteLine(mas[5]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("3 ex: ");
            string path = @"AbsolutelyRandomNameItIsException!";
            try
            {
                File.ReadAllText(path);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("4 ex: ");
            string s = "Abc";
            try
            {
                int sInt = Convert.ToInt32(s);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("5 ex: ");
            int big = 948423843;
            try
            {
                int bigger = checked(big * 984589344);
                Console.WriteLine(bigger);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("6 ex: ");
            string dirPath = @"AlsoRandomFolderYouHaveNotThisFolder :)";
            try
            {
                Directory.GetFiles(dirPath);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("7 ex: ");
            try
            {
                object o = "catch";
                int number = (int)o;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("8 ex: ");
            try
            {
                string nil = null;
                Console.WriteLine("Exception!".IndexOf(nil));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("9 ex: ");
            try
            {
                string str = "OK";
                str.Substring(15);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("10 ex: ");
            try
            {
                string secret = @"C:\Documents and Settings";
                Directory.GetDirectories(secret);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Свое исключение:");
            try
            {
                Marks marks = new(9);
                Console.WriteLine("Ваша оценка: "+marks.Mark);
            }
            catch (HSEException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
