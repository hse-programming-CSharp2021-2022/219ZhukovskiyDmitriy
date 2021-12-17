using System;
using System.Collections.Generic;

namespace TaskSet
{
    // Сиквел.
    // У Склад.LIFE большое количество различных складов с различными видами товаров.
    // Руководству важно знать, какие виды товаров находятся на различных складах. Помогите Склад.LIFE. 
    // P.S. В последнее время с заказами все плохо, поэтому на склад только завозят новые виды товаров.
    //
    // На вход программе поступают следующие запросы:
    // 1) add <storage_name> <product_name> - добавить вид товара на склад.
    // 2) get <storage_name> - получить список всех видов товаров на складе.
    // 3) exist <storage_name> <product_name> - узнать находится ли вид товара на складе.
    // 4) exit - завершить программу.

    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                RedisClient.Connect();
                string request = Console.ReadLine();
                string[] infoProducts = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                while (infoProducts[0] != "exit")
                {
                    if (infoProducts[0] == "add")
                    {
                        RedisClient.Add(infoProducts[1], infoProducts[2]);
                        request = Console.ReadLine();
                        infoProducts = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }
                    else if (infoProducts[0] == "exist")
                    {
                        if (RedisClient.ExistProduct(infoProducts[1], infoProducts[2]) == true)
                        {
                            Console.WriteLine("Указанный продукт есть на складе");
                        }
                        else
                        {
                            Console.WriteLine("Указанного продукта нет на складе");
                        }
                        request = Console.ReadLine();
                        infoProducts = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }
                    else if (infoProducts[0] == "get")
                    {
                        List<string> products = RedisClient.GetProducts(infoProducts[1]);
                        foreach (var item in products)
                            Console.WriteLine(item);
                        request = Console.ReadLine();
                        infoProducts = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    }                    
                    else
                    {
                        Console.WriteLine("Неизвестная команда. Попробуйте еще раз.");
                        request = Console.ReadLine();
                        infoProducts = request.Split(" ", StringSplitOptions.RemoveEmptyEntries);
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