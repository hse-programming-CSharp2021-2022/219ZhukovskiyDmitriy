using System;
using Microsoft.Data.Sqlite;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=MyDB1.db";
            SqliteConnection connection = new(connectionString);
            connection.Open();

            SqliteCommand command = new();
            command.Connection = connection;
            command.CommandText =
                "CREATE TABLE User(id integer not null primary key autoincrement unique, name text not null)";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO User(name) VALUES ('Tom')";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO User(name) VALUES ('Alice')";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO User(name) VALUES ('Bob')";
            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM User WHERE name='Tom'";
            command.ExecuteNonQuery();

            command.CommandText = "UPDATE User SET name='BobUpdated' WHERE name='Bob'";
            command.ExecuteNonQuery();

            command.CommandText = "SELECT * FROM USER";
            SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1));
            }
        }
    }
}