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
                if (head != null)
                {
                    head.Prev = null;
                }
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
                if (tail != null)
                {
                    tail.Next = null;
                }
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

        public void PrintReverse()
        {
            LinkedListNode<T>? current = tail;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                if (current.Prev != null)
                {
                    Console.WriteLine("↓");
                }
                current = current.Prev;
            }
        }

        public void Join(LinkedList<T> linkedList) //part 4 task 9
        {
            if ((IsEmpty() && linkedList.IsEmpty()) || (!IsEmpty() && linkedList.IsEmpty()))
            {
                return;
            }                
            else if (ReferenceEquals(this, linkedList))
            {
                Double();
            }
            else if (IsEmpty() && !linkedList.IsEmpty())
            {
                head = linkedList.head;
                tail = linkedList.tail;
            }          
            else
            {
                tail.Next = linkedList.head;
                linkedList.head.Prev = tail;
            }
        }

        public void Split(T splitFactor, out LinkedList<T> firstList, out LinkedList<T> secondList) //part 4 task 10
        {
            firstList = new LinkedList<T>();
            secondList = new LinkedList<T>();
            
            var tempHead = head;
            var currentList = firstList;

            while (tempHead is not null)
            {
                if (tempHead.Data.Equals(splitFactor))
                {
                    currentList = secondList;
                }

                currentList.Push(tempHead.Data);
                tempHead = tempHead.Next;
            }
        }

        public void Double() => Join(Clone()); //part 4 task 11

        public void Swap(int firstIndex, int secondIndex) //part 4 task 12
        {
            LinkedListNode<T> firstElement = null;
            LinkedListNode<T> secondElement = null;

            var tempHead = head;

            for (int i = 0; tempHead is not null; i++)
            {
                if (firstElement is not null && secondElement is not null)
                {
                    break;
                }
                else if(i == firstIndex)
                {
                    firstElement = tempHead;
                }
                else if (i == secondIndex)
                {
                    secondElement = tempHead;
                }

                tempHead = tempHead.Next;
            }

            if (firstElement is null || secondElement is null)
            {
                throw new ArgumentException("Invalid indexes");
            }

            var tempData = secondElement.Data;

            secondElement.Data = firstElement.Data;

            firstElement.Data = tempData;
        }

        public LinkedList<T> Clone() //for part 4 tasks (9, 11)
        {
            var cloneList = new LinkedList<T>();

            var tempHead = head;

            while (tempHead is not null)
            {
                cloneList.Push(tempHead.Data);

                tempHead = tempHead.Next;
            }

            return cloneList;
        }
    }
}
