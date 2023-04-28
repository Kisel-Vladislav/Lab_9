using System;

namespace Lab_9
{
    public class DoublyLinkedList<T>
    {
        private class DoublyNode<T>
        {
            public DoublyNode(T film = default(T),T director = default(T), T year = default(T), T genre = default(T))
            {
                this.film = film;
                this.director = director;
                this.year = year;
                this.genre = genre;
            }

            public DoublyNode<T> nodeNext;
            public DoublyNode<T> nodePrevious;
            public T film,
                     director,
                     year,
                     genre;
        }
        private DoublyNode<T> head;
        private DoublyNode<T> tail;
        private int count;

        public void Add(T film = default(T), T director = default(T), T year = default(T), T genre = default(T))
        {

            DoublyNode<T> node = new DoublyNode<T>(film, director, year, genre);

            if (head == null)
                head = node;
            else
            {
                tail.nodeNext = node;
                node.nodePrevious = tail;
            }

            tail = node;

            count++;
        }
        public void Remove(int index)
        {
            DoublyNode<T> current = head;

            while (index != 1)// && current.data != null)
            {
                current = current.nodeNext;
                index--;
            }
                if (current == head)
                {
                    head.nodePrevious = null;
                    head = current.nodeNext;
                }
                else if (current == tail)
                {
                    tail = current.nodePrevious;
                    tail.nodeNext = null;
                }
                else
                {
                    current.nodePrevious.nodeNext = current.nodeNext;
                    current.nodeNext.nodePrevious = current.nodePrevious;
                }
                count--;
        }
        public void Update(int index)
        {
            DoublyNode<T> current = head;
                
            while (index != 1)// && current.data != null)
            {
                current = current.nodeNext;
                index--;
            }

            Console.Write("Фильм : ");
            string film = Console.ReadLine();
            Console.Write("Режисер : ");
            string director = Console.ReadLine();
            Console.Write("Год : ");
            string year = Console.ReadLine();
            Console.Write("Жанр : ");
            string genre = Console.ReadLine();

            current.film = (T)Convert.ChangeType(film, typeof (T));
            current.director = (T)Convert.ChangeType(director, typeof(T));
            current.year = (T)Convert.ChangeType(year, typeof(T));
            current.genre = (T)Convert.ChangeType(genre, typeof(T));
        }
        public void Print()
        {
            DoublyNode<T> node = head;

            Console.WriteLine("\nКинопродукция");
            while (node != null)
            {
                Console.WriteLine("|{0,-20}|{1,-20}|{2,-15}|{3,-5}|", node.film, node.director, node.year, node.genre);

                node = node.nodeNext;
            }
        }
    }
}
