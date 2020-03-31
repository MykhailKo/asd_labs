using System;

namespace MyStringLab4
{
    public class MyString
    {
        private char[] _string;

        public int Len
        {
            get { return _string.Length; }
        }

        public string Val
        {
            get { return new string(_string); }
        }

        public MyString(char[] str)
        {
            _string = str;
        }

        public MyString(MyString mstr)
        {
            _string = mstr != null ? mstr._string : new char[0];
        }

        public MyString()
        {
            _string = new char[0];
        }

        public static MyString operator +(MyString left, MyString right)
        {
            MyString result = new MyString();
            result._string = new char[left.Len + right.Len];
            for (int i = 0; i < result.Len; i++)
            {
                result._string[i] = i < left.Len ? left._string[i] : right._string[i-left.Len];
            }

            return result;
        }

        public static MyString operator -(MyString str, char subst)
        {
            MyString result = new MyString();
            result._string = new char[str.Len - 1];
            int substIndex = 0;
            while (str._string[substIndex] != subst) substIndex++;

            for (int i = 0; i < result.Len; i++)
            {
                result._string[i] = i < substIndex ? str._string[i] : str._string[i + 1];
            }

            return result;
        }
    }
}