using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.LabCollections
{
    internal class QueueList<T> : IQueue<T>
    {
        private LinkedList<T> list = new LinkedList<T>();

        public void Enqueue(T obj)
        {
            list.Push(obj);
        }

        public T Dequeue()
        {
            return list.PopFront();
        }

        public bool IsEmpty()
        {
            return list.IsEmpty();
        }

        public void Print()
        {
            list.Print();
        }

        public T First()
        {
            return list.First();
        }
    }
}
