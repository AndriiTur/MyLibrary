using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class MyStack<T>: IEnumerable<T>
    {
        public const string MessageError = "Error";
        public virtual int Count { get { return List.Count; } }
        public MyLinkedList<T> List;
        public MyStack()
        {
            List = new MyLinkedList<T> { };
        }

        public void Push(T value)
        {
            List.AddFirst(value);
        }
        public T Pop()
        {
            if (List.First != null)
            {
                var temp = List.First.Value;
                List.Remove(List.First.Value);
                return temp;
            }
            throw new ArgumentOutOfRangeException("node Null", List.First, MessageError);

        }
        public T Peek()
        {
           if (List.First != null)
                return List.First.Value ;
            throw new ArgumentOutOfRangeException("node Null", List.First, MessageError);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return List.GetEnumerator();
        }
        

    }
}

