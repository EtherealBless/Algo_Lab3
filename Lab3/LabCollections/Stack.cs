using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.LabCollections
{
    internal class Stack
    {
        private LinkedList<object> list;
        public Stack()
        {
            list = new LinkedList<object>();
        }
        public void Push(object obj)
        {
            list.Push(obj);
        }
        public object? Pop()
        {
            return list.PopBack();
        }
        public object? Top()
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
