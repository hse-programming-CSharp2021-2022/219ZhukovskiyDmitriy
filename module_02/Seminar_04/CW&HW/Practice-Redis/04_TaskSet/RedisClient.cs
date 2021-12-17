using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace TaskSet
{
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;
        private static IServer server;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect("redis-15562.c100.us-east-1-4.ec2.cloud.redislabs.com:15562,password=AKPika4xlR3eFtLoRXJuPSMUj5F51eAH,ConnectTimeout=10000,allowAdmin=true");
            database = redis.GetDatabase();
            server = redis.GetServer("redis-15562.c100.us-east-1-4.ec2.cloud.redislabs.com", 15562);
        }

        public static void Add(string key, string value)
        {
            
            database.SetAdd(key, value);
            Console.WriteLine("Товар добавлен на склад");

        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static bool ExistProduct(string key, string productName)
        {
            return database.SetContains(key, productName);
        }

        public static List<string> GetProducts(string key)
        {
            return database.SetMembers(key).Select(x => x.ToString()).ToList();
        }
    }
}