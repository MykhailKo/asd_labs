using System;
using System.Collections.Generic;

namespace BusinessStorage
{
    public class Order
    {
        public static StorageEventHandler OutputDel;
        public event StorageEventHandler Output;
        private static int _counter;
        public List<OrderPosition> Positions { get; }
        public string CustomerName { get; }
        public int OrderNumber { get; }
        public string OrderDestination { get; }
        public DateTime OrderDate { get; }
        public bool Canceled { get; set; }

        public Order(string customerName, string destination, List<OrderPosition> list = null)
        {
            CustomerName = customerName;
            OrderDestination = destination;
            OrderDate = DateTime.Now;
            _counter++;
            OrderNumber = _counter;
            Output = OutputDel;
            Canceled = false;
            Positions = list == null ? new List<OrderPosition>() : list;
        }

        public void AddPosition(StStack stack, int quantity)
        {
            Positions.Add(new OrderPosition(stack, quantity));
        }

        public bool RemovePosition(OrderPosition pos) { return Positions.Remove(pos); }
        
        public void CollectOrder()
        {
            Output?.Invoke(this, new EventArgs("\nOrder number " + OrderNumber + " is being collected from storage..."));
            foreach(OrderPosition pos in Positions) pos.Items = pos.FromStack.Withdraw(pos.Quantity);
        }

        public void PrepareOrder()
        {
            Output?.Invoke(this, new EventArgs("Order number " + OrderNumber + " is being packed and loaded..."));
            foreach (OrderPosition pos in Positions) pos.PackAndLoad();
        }
    }
}