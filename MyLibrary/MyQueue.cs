using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class MyQueue<T>: IEnumerable<T> 
    {
        public const string MessageError = "Error";
        public virtual int Count { get; }
    
        public MyLinkedList<T> List = new MyLinkedList<T>();
        public MyLinkedListNode<T> Node;

        public void Enqueue(T Value)
        {
            List.AddLast(Value);
        }
        public T Dequeue()
        {
            if (List.First != null)
            {
                var temp = List.First.Value;
                List.Remove(List.First.Value);
                return temp;
            }
            throw new ArgumentOutOfRangeException("Node Null", Node = null, MessageError);
        }
        public T Peek()
        {
            if (List.First != null)
                return List.First.Value;
            throw new ArgumentOutOfRangeException("Node Null", Node = null, MessageError);
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
