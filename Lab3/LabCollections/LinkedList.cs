using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.LabCollections
{
    internal class LinkedList<T>
    {
        LinkedListNode<T>? head;
        LinkedListNode<T>? tail;

        public void Push(T data)
        {
            if (head == null)
            {
                head = new LinkedListNode<T>(data);
                tail = head;
            }
            else
            {
                Debug.Assert(tail != null, "The tail is empty. This should not be possible.");
                tail.Next = new LinkedListNode<T>(data, tail);
                tail = tail?.Next;
            }
        }

        public T? PopFront()
        {
            if (head == null)
            {
                return default;
            }
            else
            {
                T data = head.Data;
                head = head.Next;
                return data;
            }
        }

        public T? PopBack()
        {
            if (head == null)
            {
                return default;
            }
            else
            {
                Debug.Assert(tail != null, "The tail is empty. This should not be possible.");
                T data = tail.Data;
                tail = tail?.Prev;
                return data;
            }
        }



        public T? First()
        {
            if (head == null)
            {
                return default;
            }
            else
            {
                return head.Data;
            }
        }

        public T? Last()
        {
            if (tail == null)
            {
                return default;
            }
            else
            {
                return tail.Data;
            }
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void Print()
        {
            LinkedListNode<T>? current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                if (current.Next != null)
                {
                    Console.WriteLine("↓");
                }
                current = current.Next;
            }
        }
    }
}
