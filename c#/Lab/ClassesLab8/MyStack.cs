using System;
using System.Linq;

namespace ClassesLab8
{

    public class Node
    {
        public object Value { get; set; }
        public Node Parent { get; set; }
        public Node(object val, Node parent = null)
        {
            Value = val;
            Parent = parent;
        }
    }

    public class MyStack
    {
        public delegate void StackHandler(object sender, string message);
        public event StackHandler Clearing;

        private Node LastElement { get; set; }
        public MyStack(object[] arr)
        {
            Node prevEl = null;
            for (int i = 0; i < arr.Length; i++)
            {
                LastElement = prevEl == null ? new Node(arr[i]) : new Node(arr[i], prevEl);
                prevEl = LastElement;
            }
        }

        public void Put(object o)
        {
            LastElement = LastElement == null ? new Node(o) : new Node(o, LastElement);
        }
        public object Get()
        {
            if (LastElement != null)
            {
                object currVal = LastElement.Value;
                LastElement = LastElement.Parent == null ? null : LastElement.Parent;
                return currVal;
            }
            throw new IndexOutOfRangeException();
        }

        public void Clear()
        {
            Clearing?.Invoke(this,"Stack has been cleared.");
            LastElement = null;
        }
    }
}