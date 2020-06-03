using System;
using System.Threading;

namespace BusinessStorage
{
    public abstract class Good : IPrepare, ICloneable
    {
        public static StorageEventHandler OutputDel { get; set; }
        public event StorageEventHandler Output;
        public string SerialNumber { get; protected set; }
        public Packages Package { get; protected set; }
        public decimal PlainPrice { get; protected set; }
        public double Weight { get; protected set; }
        public double ShipmentVolume { get; protected set; }
        public string Name { get; protected set; }

        public Good(string name, decimal price, double weight, double volume)
        {
            if (price <= 0 || weight <= 0 || volume <= 0) throw new ArgumentException("Price, weight or volume cannot be negative!");
            Name = name;
            PlainPrice = price;
            Weight = weight;
            ShipmentVolume = volume;
            Output = OutputDel == null? null : OutputDel;
        }

        public virtual decimal GetFullPrice()
        {    
            return PlainPrice + PlainPrice*(decimal)((ShipmentVolume / Weight)/100*Storage.ShipmentCharge) + (decimal)Convert.ToInt32(Package)/10;
        }

        public override string ToString()
        {
            return Name + "\n" + SerialNumber + "\nShipment weight: " + Weight + "\nShipment volume: " + ShipmentVolume;
        }

        public abstract void Packaging();

        public virtual void Loading()
        {
            Output?.Invoke(this, new EventArgs("Item '" + Name + "' " + SerialNumber + " is being loaded..."));
        }
        public virtual object Clone() { return this; }
    }
}