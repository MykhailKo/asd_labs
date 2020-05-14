using System;

namespace ClassesLab8
{
    public class MyString
    {
        public string Value { get; private set; }

        public MyString(string str = "")
        {
            Value = str;
        }

        public static int CountDigitsStatic(string str)
        {
            int counter = 0;
            foreach (char c in str) counter += Char.IsDigit(c) ? 1 : 0;
            return counter;
        }

        public int CountDigits(string str = "")
        {
            int counter = 0;
            foreach (char c in Value) counter += Char.IsDigit(c) ? 1 : 0;
            return counter;
        }
    }
}