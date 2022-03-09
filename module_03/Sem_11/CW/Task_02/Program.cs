using System;
using System.IO;

namespace Task_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fileStream =
               new FileStream("file2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                if (fileStream.Length == 0)
                {
                    string line = "A";
                    byte[] array = System.Text.Encoding.Default.GetBytes(line);
                    fileStream.Write(array, 0, array.Length);
                }
                else
                {
                    byte[] array = new byte[fileStream.Length];
                    fileStream.Read(array, 0, array.Length);
                    string str = System.Text.Encoding.Default.GetString(array);
                    Console.WriteLine(str);
                    string new_string = ((char)(str[str.Length - 1] + 1)).ToString();
                    byte[] array2 = System.Text.Encoding.Default.GetBytes(new_string);
                    fileStream.Position = array.Length;
                    fileStream.Write(array2, 0, 1);
                }
            }
        }
    }
}
