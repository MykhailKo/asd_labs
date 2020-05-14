using System;
using System.Collections;
using ClassesLab8;

namespace Lab8Console
{
    class Program
    {
        public delegate int CountHandler(string str);
        static void Main(string[] args)
        {
            string str = "qw12er3tyu4";
            MyString ms = new MyString(str);
            CountHandler del = MyString.CountDigitsStatic;
            del += ms.CountDigits;
            //Console.WriteLine(del(str));
            //Console.WriteLine(del(str));
            
            MyStack s1 = new MyStack(new object[]{2, 5, 6, 3});
            Console.WriteLine(s1.Get());
            Console.WriteLine(s1.Get());
            Console.WriteLine(s1.Get());
            s1.Put(10);
            s1.Put(12);
            Console.WriteLine(s1.Get());
            s1.Clearing += DisplayMessage;
            s1.Clear();
        }

        public static void DisplayMessage(object sender, string message)
        {
            Console.WriteLine(message);
        }
    }
}