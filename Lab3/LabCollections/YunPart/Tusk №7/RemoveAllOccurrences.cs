using System;
using System.Collections.Generic;

namespace Lab3.LabCollections
{
    internal static class RemoveAllOccurrences
    {
        internal static void RemoveAllOccurrencesOfElement<T>(this QueueQueue<T> queue, T value)
        {
            Queue<T> tempQueue = new Queue<T>();

            while (queue.queue.Count > 0)
            {
                T current = queue.queue.Dequeue();
                if (!current.Equals(value))
                {
                    tempQueue.Enqueue(current);
                }
            }

            queue.queue = tempQueue;
        }
    }
}
