using System;
using System.Threading;

namespace BusinessStorage
{
    public class Grocery : Good, IPrepare
    {
        private static int _counter;
        public int ShelfLife { get; }
        public DateTime ExpiryDate { get; }
        public bool Fragile { get; }

        public Grocery(string name, decimal price, double weight, double volume, int slife, bool fragile)
            : base(name, price, weight, volume)
        {
            if(slife <= 0) throw new ArgumentException("Shelf life cannot be negative!");
            _counter++;
            SerialNumber = _counter + "_g";
            ShelfLife = slife;
            Fragile = fragile;
            ExpiryDate = DateTime.Now.AddDays(ShelfLife); 
        }

        public override decimal GetFullPrice()
        {
            return base.GetFullPrice() + (decimal)3;
        }
        
        public override string ToString()
        {
            return base.ToString() + "Price: " + GetFullPrice() + "\nWeight:" + Weight + "\nShelf life: " + ShelfLife + "\nExpiry date: " + ExpiryDate;
        }
        
        public override void Packaging()
        {
            Package = Fragile? Packages.WoodenBox : Packages.PaperBox;
        }

        public override void Loading()
        {
            base.Loading();
            Thread.Sleep(1000);
        }

        public override object Clone()
        {
            return new Grocery(Name, PlainPrice, Weight, ShipmentVolume, ShelfLife, Fragile);
        }
    }
}