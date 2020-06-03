using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace BusinessStorage
{
    public class Furniture : Good, IPrepare
    {
        private static int _counter;
        public string Material { get; }
        public double Width { get; }
        public double Length { get; }
        public double Height { get; }

        public Furniture(string name, decimal price, double weight, double volume, 
            string material, double width, double length, double height)
            : base(name, price, weight, volume)
        {
            if (width <= 0 || height <= 0 || length <= 0) throw new ArgumentException("Dimensions of the item cannot be negative!"); 
            _counter++;
            SerialNumber = _counter + "_f";
            Material = material;
            Width = width;
            Length = length;
            Height = height;
        }

        public override decimal GetFullPrice()
        {
            return base.GetFullPrice() + (decimal)10;
        }

        public override string ToString()
        {
            return base.ToString() + "Price: " + GetFullPrice() + "\nMaterial: " + Material + 
                   "\nDimensions: " + Length + "x" + Width + "x" + Height + "m";
        }

        public override void Packaging()
        {
            Package = Packages.WoodenBox;
        }

        public override void Loading()
        {
            base.Loading();
            Thread.Sleep(5000);
            // event for handling console output;
        }

        public override object Clone()
        {
            return new Furniture(Name, PlainPrice, Weight, ShipmentVolume, Material, Width, Length, Height);
        }
    }
}