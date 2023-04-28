using System;
using System.Collections.Generic;

namespace Задание_7
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

            count++;
        }
        public static bool IsReverse(LinkedList<T> liist1, LinkedList<T> list2)
        {
            if (liist1.count != list2.count)
                return false;

            list2 = Reverse(list2);

            Node<T> node1 = liist1.head;
            Node<T> node2 = list2.head;
            while (node1 != null)
            {
                if (!node1.data.Equals(node2.data))
                    return false;

                node1 = node1.nodeNext;
                node2 = node2.nodeNext;
            }
            return true;
        }
        private static LinkedList<T> R(Node<T> node, LinkedList<T> listRev)
        {
            if (node == null)
            {
                return null;
            }


            R(node.nodeNext, listRev);
            listRev.Add(node.data);
            return listRev;
        }
        private static LinkedList<T> Reverse(LinkedList<T> list)
        {
            LinkedList<T> rev = new LinkedList<T>();
            R(list.head, rev);
            return rev;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> ints1 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> ints2 = new List<int> { 5, 4, 3, 2, 1 };

            Console.WriteLine(IsReverse<int>(ints1, ints2));

            LinkedList<int> linkedList1 = new LinkedList<int>();
            LinkedList<int> linkedList2 = new LinkedList<int>();

            linkedList1.Add(1);
            linkedList1.Add(2);
            linkedList1.Add(3);
            linkedList1.Add(4);
            linkedList1.Add(5);

            linkedList2.Add(5);
            linkedList2.Add(4);
            linkedList2.Add(3);
            linkedList2.Add(2);
            linkedList2.Add(1);

            Console.WriteLine(LinkedList<int>.IsReverse(linkedList1, linkedList2));
        }

        static bool IsReverse<T>(List<T> list1, List<T> list2)
        {
            list2.Reverse();

            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                    return false;
            }


            return true;
        }
    }
}
