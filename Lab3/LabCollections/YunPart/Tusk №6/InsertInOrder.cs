using System;
using System.Collections.Generic;

namespace Lab3.LabCollections
{
    internal static class InsertInOrder
    {
        internal static void InsertElementInOrder<T>(this QueueQueue<T> queue, T value) where T : IComparable<T>
        {
            Queue<T> tempQueue = new Queue<T>();
            bool inserted = false;

            while (queue.queue.Count > 0)
            {
                T current = queue.queue.Dequeue();
                if (!inserted && value.CompareTo(current) <= 0)
                {
                    tempQueue.Enqueue(value);
                    inserted = true;
                }
                tempQueue.Enqueue(current);
            }

            if (!inserted)
            {
                tempQueue.Enqueue(value);
            }

            queue.queue = tempQueue;
        }
    }
}
