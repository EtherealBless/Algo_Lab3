using System;

namespace Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.RequestQueue
{
    public static class RequestQueueExample
    {
        public static void Run()
        {
            RequestQueue requestQueue = new RequestQueue();
            requestQueue.EnqueueRequest("Request 1");
            requestQueue.EnqueueRequest("Request 2");
            requestQueue.EnqueueRequest("Request 3");

            requestQueue.PrintRequests();

            Console.WriteLine("Processing request: " + requestQueue.DequeueRequest());
            Console.WriteLine("Processing request: " + requestQueue.DequeueRequest());

            requestQueue.PrintRequests();
        }
    }
}
