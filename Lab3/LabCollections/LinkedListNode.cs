using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.LabCollections
{
    internal class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T>? Next { get; set; }
        public LinkedListNode<T>? Prev { get; set; }

        public LinkedListNode(T data, LinkedListNode<T>? prev = null, LinkedListNode<T>? next = null)
        {
            Data = data;
            Prev = prev;
            Next = next;
        }
    }
}
