using System;

namespace BusinessStorage
{
    public class OrderPosition
    {
        public StStack FromStack { get; }
        public int Quantity { get; }
        public Good[] Items { get; set; }
        public OrderPosition(StStack stack, int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("The quantity in order cannot be negative!");
            FromStack = stack;
            Quantity = quantity;
        }

        public void PackAndLoad()
        {
            foreach (Good g in Items)
            {
                g.Packaging();
                g.Loading();
            }
        }
    }
}