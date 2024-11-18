using System;
using Lab3.LabCollections;

namespace Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.RequestQueue
{
    public class RequestQueue
    {
        private QueueList<string> queue;

        public RequestQueue()
        {
            queue = new QueueList<string>();
        }

        public void EnqueueRequest(string request)
        {
            queue.Enqueue(request);
        }

        public string DequeueRequest()
        {
            if (queue.IsEmpty()) return "No requests to process";
            return queue.Dequeue();
        }

        public void PrintRequests()
        {
            Console.WriteLine("Requests in queue:");
            queue.Print();
        }
    }
}
