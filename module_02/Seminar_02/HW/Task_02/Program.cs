using System;

namespace Task_02
{
    class ConsolePlate
    {
        private char _plateChar;
        private ConsoleColor _plateColor = ConsoleColor.White;
        private ConsoleColor _backColor = ConsoleColor.Black;
        public char PlateChar
        {
            get
            {
                return _plateChar;
            }
            set
            {
                if (value >= 65 || value <= 90)
                    _plateChar = value;
                else
                    _plateChar = 'A';
                
            }
        }
        public ConsoleColor PlateColor
        {
            get
            {
                return _plateColor;
            }
            set
            {
                _plateColor = value;
            }
        }
        public ConsoleColor BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }

        public ConsolePlate()
        {
            _plateChar = 'A';
        }
        
        public ConsolePlate(char _plateChar, ConsoleColor _plateColor, ConsoleColor _backColor)
        {
            if (_plateColor == _backColor)
            {
                Console.WriteLine("Фон и цвет символа не должны совпадать!");
                return;
            }
            this._plateChar = _plateChar;
            this._plateColor = _plateColor;
            this._backColor = _backColor;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePlate symbol1 = new ConsolePlate('Y', ConsoleColor.Black, ConsoleColor.Yellow);
            ConsolePlate symbol2 = new ConsolePlate('N', ConsoleColor.Yellow, ConsoleColor.DarkRed);
            Console.Write("Введите размерность: ");
            int n;
            while(!int.TryParse(Console.ReadLine(),out n)|| n<2 || n>35)
            {
                Console.Write("Введите размерность (от 2 до 35): ");
            }
            Random random = new Random();
            for (int i = 0;i<n;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int k = random.Next(0, 2);
                    if (k == 0)
                    {
                        Console.ForegroundColor = symbol1.PlateColor;
                        Console.BackgroundColor = symbol1.BackColor;
                        Console.Write(symbol1.PlateChar);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = symbol2.PlateColor;
                        Console.BackgroundColor = symbol2.BackColor;
                        Console.Write(symbol2.PlateChar);
                        Console.ResetColor();
                    }
                    
                }
                Console.WriteLine();
            }
            
        }
    }
}
