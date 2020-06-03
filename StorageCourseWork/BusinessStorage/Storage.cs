using System.Collections.Generic;
using System.Linq;

namespace BusinessStorage
{
    public class Storage
    {
        public static StorageEventHandler OutputDel;
        public event StorageEventHandler Output;
        public static float ShipmentCharge { get; set; }
        public string Name { get; set; }
        public string Location { get; set; } 
        public List<StStack> StorageStacks { get; }
        public Queue<Order> Orders { get; private set; }

        public Storage(string name, string location)
        {
            Name = name;
            Location = location;
            Output = OutputDel;
            StorageStacks = new List<StStack>();
            Orders = new Queue<Order>();
        }

        public void AddOrder(Order o) { Orders.Enqueue(o); }

        public void CancelOrder(int number)
        {
            Orders = new Queue<Order>(Orders.Where(el => el.OrderNumber != number));
        }

        public void AddStack(StStack st) { StorageStacks.Add(st); }

        public bool RemoveStack(StStack st) { return StorageStacks.Remove(st); }

        public void CompleteOrders()
        {
            Output?.Invoke(this, new EventArgs("\nStarting to complete orders on " + Name + "..."));
            while (Orders.TryDequeue(out Order curOrder))
            {
                curOrder.CollectOrder();
                curOrder.PrepareOrder();
            }
            Output?.Invoke(this, new EventArgs("All orders have been completed! Awaiting for new orders..."));
        }

    }
}