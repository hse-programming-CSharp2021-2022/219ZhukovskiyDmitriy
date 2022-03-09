using System;
using System.IO;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = "banana apple orange";
            using (FileStream fileStream =
                new FileStream("file1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(line);
                fileStream.Write(array, 0, array.Length);
            }
            using (FileStream fileStream =
                new FileStream("file1.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, array.Length);
                Console.WriteLine(
                    System.Text.Encoding.Default.GetString(array));
            }
            using (FileStream fileStream =
                new FileStream("file1.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                string replace = "abcdef";
                fileStream.Seek(0, SeekOrigin.Begin);
                byte[] array = System.Text.Encoding.Default.GetBytes(replace);
                fileStream.Write(array, 0, array.Length);
            }
            using (FileStream fileStream =
                new FileStream("file1.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] array = new byte[fileStream.Length];
                fileStream.Read(array, 0, array.Length);
                Console.WriteLine(
                    System.Text.Encoding.Default.GetString(array));
            }
            using (StreamWriter fileStream =
                new StreamWriter("file2.txt"))
            {
                fileStream.Write(line);
            }
            using (StreamReader fileStream =
                new StreamReader("file2.txt"))
            {
                Console.WriteLine(fileStream.ReadToEnd());
            }
            using (BinaryWriter fileStream =
                new BinaryWriter(new FileStream("file3.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                fileStream.Write(line);
            }
            using (BinaryReader fileStream =
                new BinaryReader(new FileStream("file3.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                Console.WriteLine(fileStream.ReadString());
            }
        }
    }
}
