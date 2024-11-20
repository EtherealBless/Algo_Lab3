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

        public void PushFront(T data)
        {
            if (head == null)
            {
                head = new LinkedListNode<T>(data);
                tail = head;
            }
            else
            {
                head.Prev = new LinkedListNode<T>(data, null, head);
                head = head?.Prev;
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
                var data = head.Data;
                head = head.Next;
                if (head != null)
                {
                    head.Prev = null;
                }
                else
                {
                    tail = null;
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
                var data = tail.Data;
                tail = tail?.Prev;
                if (tail != null)
                {
                    tail.Next = null;
                }
                else
                {
                    head = null;
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

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            var current = head;
            while (current != null)
            {
                sb.Append($"{current.Data}\n"); 
                if (current.Next != null)
                {
                    sb.Append($"↓\n"); 
                    // Console.WriteLine("↓");
                }
                current = current.Next;
            }
            return sb.ToString();
        }

        public void PrintReverse()
        {
            var current = tail;
            while (current != null)
            {
                // Console.WriteLine(current.Data);
                if (current.Prev != null)
                {
                    // Console.WriteLine("↓");
                }
                current = current.Prev;
            }
        }

        public void Reverse() //part 4 task 1
        {
            var current = head;
            LinkedListNode<T> prev = null;
            while (current != null)
            {
                var next = current.Next;
                current.Next = prev;
                current.Prev = next;
                prev = current;
                current = next;
            }
            tail = head;
            head = prev;
        }

        public void SwapFirstAndLast() //part 4 task 2
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            LinkedListNode<T> firstNode = head;
            LinkedListNode<T> lastNode = tail;

            head = lastNode;
            tail = firstNode;

            LinkedListNode<T> tempNext = firstNode.Next;
            LinkedListNode<T> tempPrev = lastNode.Prev;

            firstNode.Next = null;
            firstNode.Prev = tempPrev;
            lastNode.Next = tempNext;
            lastNode.Prev = null;

            if (tempNext != null)
                tempNext.Prev = lastNode;
            if (tempPrev != null)
                tempPrev.Next = firstNode;

            if (head.Next == null)
                tail = head;
            if (tail.Prev == null)
                head = tail;
        }

        public int CountUniqueInts() //part 4 task 3
        {
            var type = typeof(T);
            if (type != typeof(int) && type != typeof(object))
            {
                return 0;
            }

            var uniqueInts = new HashSet<int>();
            var current = head;
            int totalNodes = 0;

            while (current is not null)
            {
                totalNodes++;
                if (int.TryParse(current.Data?.ToString(), out int intData))
                {
                    uniqueInts.Add(intData);
                }
                current = current.Next;
            }

            return uniqueInts.Count;
        }

        public void RemoveDuplicates() //part 4 task 4
        {
            var uniqueElements = new HashSet<T>();

            var current = head;

            while (current is not null)
            {
                if (!uniqueElements.Contains(current.Data))
                {
                    uniqueElements.Add(current.Data);
                }
                else
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        tail = current.Prev;
                    }
                }

                current = current.Next;
            }
        }

        public void InsertSelfAfter(T value) //part 4 task 5
        {
            var current = head;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    var newList = this.Clone();
                    var nextNode = current.Next;
                    current.Next = newList.head;
                    newList.head.Prev = current;
                    newList.tail.Next = nextNode;
                    if (nextNode != null)
                    {
                        nextNode.Prev = newList.tail;
                    }
                    else
                    {
                        tail = newList.tail;
                    }
                    break;
                }
                current = current.Next;
            }

        }

        public void InsertInSortedOrder(T value) //part 4 task 6
        {
            var current = head;
            if (current == null) return;

            while (current != null)
            {
                var comparable = current.Data as IComparable<T>;
                if (comparable?.CompareTo(value) >= 0)
                {
                    var newNode = new LinkedListNode<T>(value);
                    if (current.Prev != null)
                    {
                        current.Prev.Next = newNode;
                        newNode.Prev = current.Prev;
                    }
                    else
                    {
                        head = newNode;
                    }
                    newNode.Next = current;
                    current.Prev = newNode;
                    return;
                }
                current = current.Next;
            }
            // If we get here, add to the end
            Push(value);
        }

        public void RemoveAllOccurrences(T value) //part 4 task 7
        {
            var current = head;
            if (current == null) return;

            while (current != null)
            {
                if (current.Data?.Equals(value) == true)
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        tail = current.Prev;
                    }
                }
                current = current.Next;
            }
        }

        public void InsertBeforeFirstOccurrence(T valueToInsert, T valueToFind) //part 4 task 8
        {
            Console.WriteLine($"Inserting {valueToInsert} before first occurrence of {valueToFind}");
            var current = head;
            if (current == null)
            {
                Console.WriteLine("List is empty. Returning.");
                return;
            }

            while (current != null)
            {
                Console.WriteLine($"Checking node with value: {current.Data}");
                if (current.Data?.Equals(valueToFind) == true)
                {
                    Console.WriteLine($"Found {valueToFind}. Inserting {valueToInsert} before it.");
                    var newNode = new LinkedListNode<T>(valueToInsert);
                    if (current.Prev != null)
                    {
                        Console.WriteLine("Inserting in the middle of the list.");
                        current.Prev.Next = newNode;
                        newNode.Prev = current.Prev;
                    }
                    else
                    {
                        Console.WriteLine("Inserting at the head of the list.");
                        head = newNode;
                    }
                    newNode.Next = current;
                    current.Prev = newNode;
                    Console.WriteLine("Insertion complete.");
                    break;
                }
                current = current.Next;
            }
            if (current == null)
            {
                Console.WriteLine($"{valueToFind} not found in the list.");
            }
        }

        public void Join(params object[] values) //part 4 task 9
        {
            LinkedList<T> linkedList = new();
            foreach (var value in values)
            {
                linkedList.Push((T)value);
            }
            Join(linkedList);
        }

        public void Join(LinkedList<T> linkedList) //part 4 task 9
        {
            if (!IsEmpty() && !linkedList.IsEmpty())
            {
                if (tail != null && linkedList.head != null)
                {
                    tail.Next = linkedList.head;
                    linkedList.head.Prev = tail;
                    tail = linkedList.tail;
                }
            }
        }

        public (LinkedList<T>, LinkedList<T>) Split(T splitFactor) //part 4 task 10
        {
            var firstList = new LinkedList<T>();
            var secondList = new LinkedList<T>();

            var tempHead = head;

            var currentList = firstList;

            while (tempHead is not null)
            {
                if (tempHead.Data?.Equals(splitFactor) ?? splitFactor == null)
                {
                    currentList = secondList;
                }

                currentList.Push(tempHead.Data);
                tempHead = tempHead.Next;
            }

            return (firstList, secondList);
        }

        public void Double() => Join(Clone()); //part 4 task 11

        public void Swap(int firstIndex, int secondIndex) //part 4 task 12
        {
            LinkedListNode<T>? firstElement = null;
            LinkedListNode<T>? secondElement = null;

            var tempHead = head;

            for (int i = 0; tempHead is not null; i++)
            {
                if (firstElement is not null && secondElement is not null)
                {
                    break;
                }
                else if (i == firstIndex)
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
                throw new ArgumentException("Error: Invalid indexes");
            }

            (firstElement.Data, secondElement.Data) = (secondElement.Data, firstElement.Data);
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
