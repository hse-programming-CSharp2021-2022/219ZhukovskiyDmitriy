using System;
using StackExchange.Redis;

namespace TaskList
{
    public static class RedisClient
    {
        /// <summary>
        /// Maximum number of versions to store
        /// </summary>
        public const uint MaxCount = 5;

        private static ConnectionMultiplexer redis;
        private static IDatabase database;
        private static IServer server;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect("redis-15562.c100.us-east-1-4.ec2.cloud.redislabs.com:15562,password=AKPika4xlR3eFtLoRXJuPSMUj5F51eAH,ConnectTimeout=10000,allowAdmin=true");
            database = redis.GetDatabase();
            server = redis.GetServer("redis-15562.c100.us-east-1-4.ec2.cloud.redislabs.com", 15562);
        }

        public static string Get(string key)
        {
            if (Exist(key))
            {
                return database.ListGetByIndex(key, database.ListLength(key) - 1);
            }
            return "Приложения нет";
        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static void Add(string key, string value)
        {

            if (Exist(key))
            {
                if (database.ListLength(key) < MaxCount)
                {
                    database.ListRightPush(key, value);
                    Console.WriteLine("Добавлена новая версия");
                }
                else
                {
                    Console.WriteLine("Уже есть 5 версий приложения.");
                }
            }
            else
            {
                database.ListRightPush(key, value);
                Console.WriteLine("Приложение создано!");
            }
        }

        public static string Back(string key)
        {
            database.ListRightPop(key);
            if (database.ListLength(key) != 0)
            {
                return database.ListGetByIndex(key, database.ListLength(key) - 1);
            }
            else
            {
                database.KeyDelete(key);
                return "Приложение удалено";
            }

        }
    }
}