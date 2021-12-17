using System;

namespace TaskList
{
    // Сиквел.
    // Разработчики из HSE company просят доработать ваше приложение!
    // Дело в том, что разработчики тоже ошибаются, и приходится откатывать приложение к предыдущей версии.
    // К тому же, HSE company не хочет расходовать много памяти,
    // поэтому было принято решение хранить только определенное колличество последних версий приложений (MaxCount).
    // 
    // На вход программе подаются запросы следующего типа:
    // 1) add <application_name> <version> - добавить актуальную версию приложения.
    // 2) back <application_name> - откатить приложение до предыдущей версии. Если предыдущей нет, то удалить приложение.
    // 3) get <application_name> - получить актуальную версию приложения. Если приложения нет, то сообщить об этом.
    // 4) exit - завершить программу.

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RedisClient.Connect();
                string request = Console.ReadLine();
                string[] version = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                while (version[0] != "exit")
                {
                    if (version[0] == "add")
                    {
                        RedisClient.Add(version[1], version[2]);
                        request = Console.ReadLine();
                        version = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }
                    else if (version[0] == "back")
                    {
                        Console.WriteLine(RedisClient.Back(version[1]));
                        request = Console.ReadLine();
                        version = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }
                    else if (version[0] == "get")
                    {
                        Console.WriteLine(RedisClient.Get(version[1]));
                        request = Console.ReadLine();
                        version = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                        Console.WriteLine("Неизвестная команда. Попробуйте еще раз.");
                        request = Console.ReadLine();
                        version = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}