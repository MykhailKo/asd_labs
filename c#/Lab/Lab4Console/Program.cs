using System;
using MyStringLab4;

namespace Lab4Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString ms1 = new MyString(new []{'4', '5', '6'});
            MyString ms2 = new MyString(ms1);
            MyString ms3 = new MyString();
            
            ms2 = ms2 - '5';
            
            ms3 = ms1 + ms2;

            Console.WriteLine(ms1.Val);
            Console.WriteLine(ms2.Val);
            Console.WriteLine(ms3.Val);
        }
    }
}