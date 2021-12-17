﻿using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace TaskIntSolution
{
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;
        private static IServer server;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect("redis-19876.c72.eu-west-1-2.ec2.cloud.redislabs.com:19876,password=cg7bY38Ry4NjsESqKVeVXKSgD1CPc1lj,ConnectTimeout=10000,allowAdmin=true");
            database = redis.GetDatabase();
            server = redis.GetServer("redis-19876.c72.eu-west-1-2.ec2.cloud.redislabs.com", 19876);
        }

        public static void AddOne(string key)
        {
            if (Exist(key))
            {
                database.StringIncrement(key);
            }
            else
            {
                database.StringSet(key, 1);
            }
        }

        public static void RemoveOne(string key)
        {
            if (database.StringDecrement(key) <= 0)
            {
                database.KeyDelete(key);
            }
        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static long GetAsLong(string key)
        {
            return (long)database.StringGet(key);
        }

        /// <summary>
        /// Get keys in Redis server with special beginning.
        /// </summary>
        /// <param name="keyBeginning"> Special beginning. </param>
        public static string[] GetKeys(string keyBeginning = "")
        {
            return server.Keys(pattern: $"{keyBeginning}*")
                .Select(x => x.ToString())
                .ToArray();
        }
    }
}