using System;
using System.Collections.Generic;

namespace Lab3.LabCollections
{
    internal static class InsertBeforeElement
    {
        internal static void InsertBeforeFirstOccurrence<T>(this QueueQueue<T> queue, T valueToInsert, T valueToFind)
        {
            Queue<T> tempQueue = new Queue<T>();
            bool found = false;

            while (queue.queue.Count > 0)
            {
                T current = queue.queue.Dequeue();
                if (current.Equals(valueToFind) && !found)
                {
                    tempQueue.Enqueue(valueToInsert);
                    found = true;
                }
                tempQueue.Enqueue(current);
            }

            queue.queue = tempQueue;
        }
    }
}
    