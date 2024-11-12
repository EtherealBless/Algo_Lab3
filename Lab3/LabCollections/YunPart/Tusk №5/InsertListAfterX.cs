using System;
using System.Collections.Generic;

namespace Lab3.LabCollections
{
    internal static class InsertListAfterX
    {
        internal static void InsertListAfterFirstOccurrence<T>(this QueueQueue<T> queue, T x)
        {
            // Сохраняем копию исходного списка
            Queue<T> originalQueue = new Queue<T>(queue.queue);

            Queue<T> tempQueue = new Queue<T>();
            bool found = false;

            while (queue.queue.Count > 0)
            {
                T current = queue.queue.Dequeue();
                tempQueue.Enqueue(current);

                if (current.Equals(x) && !found)
                {
                    found = true;
                    // Вставить копию исходного списка после первого вхождения x
                    Queue<T> copyQueue = new Queue<T>(originalQueue);
                    while (copyQueue.Count > 0)
                    {
                        tempQueue.Enqueue(copyQueue.Dequeue());
                    }
                }
            }

            queue.queue = tempQueue;
        }
    }
}
