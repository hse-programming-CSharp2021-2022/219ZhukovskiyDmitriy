using System;
using StackExchange.Redis;

namespace TaskStringSolution
{
    class Program
    {
        // Разработчики одной крупной компании (HSE company) столкнулись с такой проблемой:
        // HSE company выпускает множество программных продуктов и постоянно их обновляет. 
        // Разработчики поняли, что хранить в Excel-таблице актуальные версии приложений неудобно; 
        // но времени на решение этой задачи у них совсем не осталось.
        // Помогите им!
        //
        // На вход поступают запросы вида: name_of_application new_version.
        // Требуется вывести текущую версию приложения и заменить ее на новую (если оно было в Redis),
        // или же вывести, что такого приложения не существует, и добавить его в Redis.

        static void Main(string[] args)
        {
            try
            {
                RedisClient.Connect();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string query;
            int i = 0;
            while (i++ < 10)
            {
                Console.WriteLine("input: ");
                query = Console.ReadLine();

                string[] inputLines = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = inputLines[0];
                string newVersion = inputLines[1];

                if (RedisClient.Exist(name))
                {
                    Console.WriteLine(RedisClient.Get(name));
                    Console.WriteLine(RedisClient.GetSet(name, newVersion));
                }
                else
                {
                    RedisClient.Set(name, newVersion);
                    Console.WriteLine("newVersion set");
                }
            }
        }
    }
}