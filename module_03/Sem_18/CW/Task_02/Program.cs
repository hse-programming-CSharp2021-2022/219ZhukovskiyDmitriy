using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Task_02
{
    class Program
    {
        private const string connectionString = "Data Source=AdventureWorksLT.db";

        static void Main(string[] args)
        {
            // Sql request 1.
            var SQL1 = "UPDATE Product SET StandardCost = 50 WHERE ProductID = 680";
            ExecuteSQL_DataTable(connectionString, SQL1);

            // Sql request 2.
            var SQL2 = "UPDATE Product SET ListPrice = 78 WHERE ProductID = 680";
            ExecuteSQL_DataTable(connectionString, SQL2);

            // Sql request 3.
            var SQL3 = "DELETE FROM Product WHERE ProductId = 1";
            ExecuteSQL_DataTable(connectionString, SQL3);

            // Sql request 4.
            var SQL4 =
                "INSERT INTO Product (ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, SellStartDate, rowguid) " +
                "VALUES (73810, 'NewFuckingProduct1', 'SH-00-013710718', 'Red', 100, 90, '2022-03-21 21:21:21', '5301997')";
            ExecuteSQL_DataTable(connectionString, SQL4);

            // Sql request 5.
            var SQL5 = "DELETE FROM Product WHERE ProductId = 706";
            ExecuteSQL_DataTable(connectionString, SQL5);

            // Sql request 6.
            var SQL6 = "SELECT * FROM Product WHERE ListPrice < 700 and ListPrice > 560";
            var dataTable6 = ExecuteSQL_DataTable(connectionString, SQL6);
            PrintTable(dataTable6);

            Console.WriteLine("\n\n\n");

            var SQL7 = "SELECT * FROM Product WHERE INSTR(Name, 'Product')";
            var dataTable7 = ExecuteSQL_DataTable(connectionString, SQL7);
            PrintTable(dataTable7);

            Console.WriteLine("\n\n\n");

            var SQL8 = "SELECT * FROM Product WHERE ProductId = 1";
            var dataTable8 = ExecuteSQL_DataTable(connectionString, SQL8);
            PrintTable(dataTable8);
        }

        private static void PrintTable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
            }
        }

        private static DataTable ExecuteSQL_DataTable(string connectionString, string SQL, params Tuple<string, string>[] parameters)
        {
            var dt = new DataTable();
            using var connection = new SqliteConnection(connectionString);
            using var command = new SqliteCommand(SQL, connection);

            command.CommandType = CommandType.Text;
            foreach (var tuple in parameters)
                command.Parameters.Add(new SqliteParameter(tuple.Item1, tuple.Item2));

            connection.Open();
            var reader = command.ExecuteReader();
            for (var i = 0; i < reader.FieldCount; i++)
                dt.Columns.Add(new DataColumn(reader.GetName(i)));

            var rowIndex = 0;
            while (reader.Read())
            {
                var row = dt.NewRow();
                dt.Rows.Add(row);

                for (var i = 0; i < reader.FieldCount; i++)
                    dt.Rows[rowIndex][i] = (reader.GetValue(i));
                rowIndex++;
            }

            return dt;
        }
    }
}