using System;
using System.Text;

namespace Task_01
{
    class VideoFile
    {
        private string _name;
        private int _duration;
        private int _quality;
        public int Size { get { return _duration * _quality; } set { } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Duration { get { return _duration; } set { _duration = value; } }
        public int Quality { get { return _quality; } set { _quality = value; } }
        public VideoFile(string _name,int _duration,int _quality)
        {
            this._name = _name;
            this._duration = _duration;
            this._quality = _quality;
        }
        public override string ToString()
        {
            return $"Имя видеофайла:{_name}" + "\n" + $"Длительность видеофайла:{_duration}" + "\n" + $"Качество видеофайла:{_quality}" + "\n"
                + $"Размера видеофайла: {Size}";
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Random random = new();
                VideoFile[] videos = new VideoFile[random.Next(5, 16)];
                Console.WriteLine($"Вы получили массив длины {videos.Length}" + "\n");
                for (int i = 0; i < videos.Length; i++)
                {
                    StringBuilder creation = new();
                    int nameLength = random.Next(2, 10);
                    for (int j = 0; j < nameLength; j++)
                    {
                        creation.Append((char)random.Next('A', 'Z' + 1));
                    }
                    string name = creation.ToString();
                    int duration = random.Next(60, 361);
                    int quality = random.Next(100, 1001);
                    videos[i] = new(name, duration, quality);
                }
                int videoNumber = random.Next(1, videos.Length);
                Console.WriteLine($"Сравниваем размера других видеофайлов с видеофайлом, имеющим индекс в массивe {videoNumber - 1}" + "\n");
                int count = 0;
                for (int i = 0; i < videos.Length; i++)
                {
                    if (videos[i].Size > videos[videoNumber - 1].Size)
                    {
                        Console.WriteLine(videos[i] + "\n");
                        count++;
                    }
                    
                }
                if (count == 0)
                {
                    Console.WriteLine("Был выбран видеофайл максимального размера!"+"\n");
                }
                Console.WriteLine("Нажмите ESC, чтобы завершить работу программы.");
                Console.WriteLine("Иначе нажмите любую клавишу.");
                
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
