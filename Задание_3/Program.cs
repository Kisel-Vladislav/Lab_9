using System;

namespace Задание_3
{
    public class LinkedList<T>
    {
        private class Node<T>
        {
            public Node(T data = default(T))
            {
                this.data = data;
            }

            public Node<T> nodeNext;
            public T data;
        }
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.nodeNext = node;

            tail = node;
            tail.nodeNext = head;
            count++;
        }
        public void Play(string text, string nameFirst)
        {
            Node<T> node = head;
            int i = count;
            while (Convert.ToString(node.data) != nameFirst)
            {
                node = node.nodeNext;
                i--;

                if (i == 0)
                {
                    Console.WriteLine("Такого игрока нет");
                    return;
                }

            }


            string[] words = text.Split();

            for (int j = 1; j < words.Length; j++)
                node = node.nodeNext;

            Console.WriteLine("Подследние слово прийдется на " + "\"" +node.data + "\"");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Мама свин");
            list.Add("Папа свин");
            list.Add("Пепа");
            list.Add("Джош");
            list.Add("Bob");

            while (true)
            {
                Console.WriteLine("Players: \"Мама свин\", \"Папа свин\", \"Пепа\", \"Джош\", \"Bob\".");
                Console.Write("Text: ");
                string text = Console.ReadLine();
                Console.Write("С кого начинать ");
                string firstPlayer = Console.ReadLine();
                list.Play(text, firstPlayer);
            }

            
        }

    }
}