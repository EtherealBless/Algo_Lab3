using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.LabCollections
{
    // insertion/deletion of an element, check for emptiness, print, output of the first element.
    internal class QueueQueue<T> : IQueue<T>
    {
        private Queue<T> queue = new Queue<T>();

        public void Enqueue(T value) => queue.Enqueue(value);

        public T Dequeue() => queue.Dequeue();

        public bool IsEmpty() => queue.Count == 0;

        public void Print() => Console.WriteLine(string.Join(" ", queue));

        public T First() => queue.Peek();
    }
}
