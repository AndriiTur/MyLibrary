using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
  

   

    public class MyLinkedListNode<T> 
    {
        private T value;
        internal MyLinkedListNode<T> previous;
        internal MyLinkedListNode<T> next;
        private MyLinkedList<T> ovner;

        public T Value { get { return value; } }
        public MyLinkedListNode<T> Previous { get { return previous; } }
        public MyLinkedListNode<T> Next { get { return next; } }
        internal MyLinkedList<T> Ovner { get { return ovner; } }

        public MyLinkedListNode(MyLinkedList<T> ovner, T value)
        {
            this.value = value;
            this.ovner = ovner;
        }
    }
         
    public class MyLinkedList<T> : IEnumerable<T>
    {
        public const string MessageError = "Error";
        
        private MyLinkedListNode<T> first;
        private MyLinkedListNode<T> last;
        private int count;

        internal IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int Count { get { return count; } }
        public MyLinkedListNode<T> First { get { return first; } }
        public MyLinkedListNode<T> Last { get { return last; } }

        public MyLinkedList()
        {

        }
       
        public void AddAfter(MyLinkedListNode<T> node, T value)
        {
            if (node.Ovner != this)
                throw new ArgumentOutOfRangeException("ovne False", node = null, MessageError);
            
            if (node == this.last)
            {
                this.AddLast(value);
                return;
            }
            var newNode = new MyLinkedListNode<T>(this, value);
            var nodeNext = node.Next; 
            node.next = newNode;
            newNode.previous = node;
            nodeNext.previous = newNode;
            newNode.next = nodeNext;
            
            this.count++;

        }

        public void AddFirst(T value)
        {
            var newNode = new MyLinkedListNode<T>(this, value);
            if (this.First == null)
            {
                this.first = newNode;
                this.last = newNode;
            }
            else
            {
                this.First.previous = newNode;
                newNode.next = this.First;
                this.first = newNode;
            }          
            this.count++;


        }

        public void AddLast(T value)
        {
            var newNode = new MyLinkedListNode<T>(this,value);
            if (this.First == null)
            {
                this.first = newNode;
                this.last = newNode;
            }
            else
            {
                
                this.Last.next = newNode;
                newNode.previous = this.Last;
                this.last = newNode;  
            }

            this.count++;
        }

        public void Remove(T value)
        {
           
            var node = this.First;
           
            while ((node != null) && !node.Value.Equals(value))
            {
                node = node.Next;
            }
            if (node == null)
                throw new ArgumentOutOfRangeException("node null",node = null,MessageError);
            if ((node == this.First) && (node == this.Last))
            {

                this.first = null;
                this.last = null;
            }
            else
            if (node == this.First)
            {
                var temp = this.First.Next;
                this.First.Next.previous = null;
                this.First.next = null;
                this.first = temp;
            }
            else
            if (node == this.Last)
            {
                var temp = this.Last.Previous;
                this.Last.Previous.next = null;
                this.Last.previous = null;
                this.last = temp;
            }
            else
            if ((node != this.First) && (node != this.Last))
            {
                node.Previous.next = node.Next;
                node.Next.previous = node.Previous;
                node.previous = null;
                node.next = null;
            }
            this.count--;

        }

        public void Clear()
        {
            while (this.First != null)
                this.Remove(this.First.Value);
        }

        public T[] ToArray()
        {
            var node = this.First;
            int i = 0;
            var arrResult = new T[Count];
            while (node != null) 
            {
                arrResult[i] = node.Value;
                i++;
                node = node.Next;
            }
            return arrResult;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new MyLinkedListEnum<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyLinkedListEnum<T>(this);
        }
    }

    public class MyLinkedListEnum<T> : IEnumerable<T> , IEnumerator<T>
    {
        public MyLinkedListNode<T> Node;
        public MyLinkedList<T> ListR;
        public MyLinkedListEnum(MyLinkedList<T> List)
        {
            Node = List.First.Previous;
            ListR = List;
        }

        T IEnumerator<T>.Current { get { return Node.Value;}}

        object IEnumerator.Current { get { return Node.Value; } }

        
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)ListR).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)ListR).GetEnumerator();
        }

        void IDisposable.Dispose()
        {
            Node = null;
            ListR = null;
        }

        bool IEnumerator.MoveNext()
        {
            if (Node == ListR.Last)
            {
                return false;
            }
            if (Node == null)
                Node = ListR.First;
            else
                Node = Node.Next;
            return true;
        }

        void IEnumerator.Reset()
        {
            Node = null;
        }
    }
}
