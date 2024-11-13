using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.LabCollections
{
    internal class Stack<T>
    {
        private LinkedList<T> list;
        public Stack()
        {
            list = new LinkedList<T>();
        }
        public void Push(T obj)
        {
            list.Push(obj);
        }
        public T? Pop()
        {
            return list.PopBack();
        }
        public T? Top()
        {
            return list.Last();
        }
        public bool IsEmpty()
        {
            return list.IsEmpty();
        }
        public void Print()
        {
            list.Print();
        }
    }
}
