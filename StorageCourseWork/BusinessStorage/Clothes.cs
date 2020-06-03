using System;
using System.IO.Compression;
using System.Threading;

namespace BusinessStorage
{
    public enum Sizes
    {
        XS = 44,
        S = 46,
        M = 48,
        L = 50,
        XL = 52,
        XXL = 54
    }
    public class Clothes : Good, IPrepare
    {
        private static int _counter;
        public Sizes Size { get; }
        public string Material { get; }
        public string Brand { get; }

        public Clothes(string name, decimal price, double weight, double volume, Sizes size, string material, string brand)
            :base(name, price, weight, volume)
        {
            _counter++;
            SerialNumber = _counter + "_c";
            Size = size;
            Material = material;
            Brand = brand;
        }
        public override decimal GetFullPrice()
        {
            return base.GetFullPrice() + (decimal) 2;
        }

        public override string ToString()
        {
            return base.ToString() + "\nPrice: " + GetFullPrice() + "\nBrand: " + Brand + "\nSize: " + Size + "\nMaterial: " + Material;
        }

        public override void Packaging()
        {
            Package = Packages.PlasticBag;
        }
        public override void Loading()
        {
            base.Loading();
            Thread.Sleep(500);
            // Event for handling console output
        }

        public override object Clone()
        { 
            return new Clothes(Name, PlainPrice, Weight, ShipmentVolume, Size, Material, Brand);
        }
    }
}