using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.LabCollections
{
    internal interface IQueue<T>
    {
        public void Enqueue(T value);
        public T? Dequeue();
        public bool IsEmpty();
        public void Print();
        public T? First();

    }
}
