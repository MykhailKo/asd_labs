using System;
using MyArrayLab3;

namespace Lab3Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = new int[3][];
            array[0] = new[] {1, 44, 12, 6, 87};
            array[1] = new[] {2, 43, 6, 7};
            array[2] = new[] {34, 76};
            
            MyArray ma = new MyArray(array);
            ma.AddRow(new [] {1, 4, 5, 6});
            ma.DeleteRow(1);
            
            Console.WriteLine(ma.Sum);
            Console.WriteLine(ma[1]);
            Console.WriteLine(ma[0]);
        }
    }
}