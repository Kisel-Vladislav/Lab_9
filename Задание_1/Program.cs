using System;
using System.Collections.Generic;

namespace Lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool close = false;

            List<string> table = new List<string>();
            DoublyLinkedList<string> myList = new DoublyLinkedList<string>();

            while (!close)
            {
                Console.WriteLine("1 – Просмотр таблицы\r\n" +
                                  "2 – Добавить запись\r\n" +
                                  "3 – Удалить запись\r\n" +
                                  "4 – Обновить запись\r\n" +
                                  "5 - Выход\n");
                ConsoleKey key = Console.ReadKey().Key;
                Console.WriteLine();

                switch (key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:    // Просмотр таблицы
                        {
                            //Print();

                            myList.Print();
                            break;
                        }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:    // Добавить запись 
                        {
                            //Add();
                            
                            Console.Write("Фильм : ");
                            string film = Console.ReadLine();
                            Console.Write("Режисер : ");
                            string director = Console.ReadLine();
                            Console.Write("Год : ");
                            string year = Console.ReadLine();
                            Console.Write("Жанр : ");
                            string genre = Console.ReadLine();
                            myList.Add(film,director,year,genre);
                            break;
                        }
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:    // Удалить запись 
                        {
                            //Delete();

                            myList.Print();
                            Console.WriteLine("Удалить запись  № _?_ ");
                            myList.Remove(int.Parse(Console.ReadLine()));
                            break;
                        }
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:    // Обновить запись
                        {
                            //Update();

                            myList.Print();
                            Console.WriteLine("Изменить запись  № _?_ ");
                            myList.Update(int.Parse(Console.ReadLine()));
                        }
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:    // Выход
                        close = true;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }

            void Print()
            {
                Console.WriteLine("\nКинопродукция");
                for (int i = 0; i < table.Count; i++)
                    Console.WriteLine("|{0,-20}|{1,-20}|{2,-15}|{3,-5}|", table[i++], table[i++], table[i++], table[i]);
            }
            void Delete()
            {
                Print();
                Console.WriteLine("Запись № _?_");
                int nom = int.Parse(Console.ReadLine());
                table.RemoveRange((nom -1)*4, 4);
            }
            void Add()
            {
                Console.Write("Фильм : ");
                table.Add(Console.ReadLine());
                Console.Write("Режисер : ");
                table.Add(Console.ReadLine());
                Console.Write("Год : ");
                table.Add(Console.ReadLine());
                Console.Write("Жанр : ");
                table.Add(Console.ReadLine());
            }
            void Update()
            {
                Delete();
                Console.WriteLine();
                Add();
            }
        }
    }
}
