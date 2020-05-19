namespace MyListLab7
{
    public class Node
    {
        public double Value { get; set; }
        public Node Next { get; set; }
        public Node(double data)
        {
            Value = data;
        }
        
    }
    
    public delegate void OutputHandler(object o, double val); 
    public class MyList
    {
        public event OutputHandler Output;
        
        private Node _head;
        private Node _tail;
        public int Count { get; private set; }
        public double Sum { get; private set; }

        public void Add(double data)
        {
            Node nodeAdd = new Node(data);
            if (_head == null) _head = nodeAdd;
            else _tail.Next = nodeAdd;
            _tail = nodeAdd;
            Count++;
            Sum += data;
        }

        public void RemoveEven()
        {
            if (_head != null && _head != _tail)
            {
                Node curNode = _head;
                Node nextNode = _head.Next;
                while (nextNode != null)
                {
                    if (nextNode.Next == null)
                    {
                        _tail = curNode;
                        Count--;
                        Sum -= _tail.Next.Value;
                        _tail.Next = null;
                        nextNode = null;
                    }
                    else
                    {
                        Count--;
                        Sum -= curNode.Next.Value;
                        curNode.Next = nextNode.Next;
                        curNode = curNode.Next;
                        nextNode = curNode.Next;
                    }
                } 
            }    
        }

        public int FindNumOfMoreThanAverage()
        {
            double average = Sum / Count;
            int num = 0;
            Node curNode = _head;
            while (curNode != null)
            {
                if (curNode.Value > average) num++;
                curNode = curNode.Next;
            }
            return num;
        }
        public void ShowList()
        {
            Node curNode = _head;
            while (curNode != null)
            {
                Output?.Invoke(this, curNode.Value);
                curNode = curNode.Next;
            }
        }
    }
}

/*public bool Remove(double data)
        {
            Node curNode = _head;
            Node prevNode = null;
            while (curNode != null)
            {
                if (curNode.Value.Equals(data))
                {
                    if (prevNode != null)
                    {
                        prevNode.Next = curNode.Next;
                        if (curNode.Next == null) _tail = prevNode;
                    }
                    else
                    {
                        _head = _head.Next;
                        if (_head == null) _tail = null;
                    }
                    Count--;
                    Sum -= data;
                    return true;
                }
                prevNode = curNode;
                curNode = curNode.Next;
            }
            return false;
        }
*/