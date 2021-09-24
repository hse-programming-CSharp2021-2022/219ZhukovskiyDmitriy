using System;

namespace Task_01
{
    class Program
    {
        public static bool Shift(ref char ch)
        {
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            
            for (int i = 0; i < letters.Length; i++)
            {

                char temp;
                if (ch == letters[i] && i < 22)
                {
                    temp = ch;
                    ch = letters[i + 4];
                   
                    if (ch!=temp)
                    {
                        return true;
                    }
                    break;
                }
                if (ch == 'w')
                {
                    temp = ch;
                    ch = 'a';
                    
                    if (ch != temp)
                    {
                        return true;
                    }
                    break;
                }
                if (ch == 'x')
                {
                    temp = ch;
                    ch = 'b';
                    
                    if (ch != temp)
                    {
                        return true;
                    }
                    break;
                }
                if (ch == 'y')
                {
                    temp = ch;
                    ch = 'c';
                    
                    if (ch != temp)
                    {
                        return true;
                    }
                    break;
                }
                if (ch == 'z')
                {
                    temp = ch;
                    ch = 'd';
                   
                    if (ch != temp)
                    {
                        return true;
                    }
                    break;
                }
            }
           
            return false;
        }
        static void Main(string[] args)
        {
            char ch;
            do Console.Write("Введите строчныый символ латинского алфавита: ");
            while (!char.TryParse(Console.ReadLine(), out ch));
            Console.WriteLine(Shift(ref ch));





        }
    }
}
