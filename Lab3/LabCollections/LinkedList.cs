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
        // Push(elem), Pop(), Top(), isEmpty(), Print().

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

        public T Pop()
        {
            if (head == null)
            {
                throw new Exception("The list is empty");
            }
            else
            {
                T data = head.Data;
                head = head.Next;
                return data;
            }
        }

        public T Top()
        {
            if (head == null)
            {
                throw new Exception("The list is empty");
            }
            else
            {
                return head.Data;
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
