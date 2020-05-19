using System;
using MyListLab7;

namespace Lab7Console
{
    class Program
    {
        static void Main(string[] args)
        { 
            MyList list = new MyList();
            list.Output += Display;
            list.Add(1.1);
            list.Add(1.2);
            list.Add(1.3);
            list.Add(1.4);
            list.Add(1.5);
            list.Add(1.6);
            list.ShowList();
            Console.WriteLine(list.FindNumOfMoreThanAverage());
            list.RemoveEven();
            list.ShowList();
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Sum);
        }

        public static void Display(object o, double val)
        {
            Console.WriteLine(val);            
        }
    }
}