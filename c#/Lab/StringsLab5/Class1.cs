using System;
using System.Linq;
using System.Text;

namespace StringsLab5
{
    public class MyString
    {
        protected char[] _string;
        
        public int Len => _string.Length;

        public MyString(char[] str)
        {
            _string = str;
        }
        public MyString()
        {
            _string = new char[0];
        }
    }

    public class LetterString : MyString
    {
        public string Val => new string(_string);
        
        public LetterString(char[] str):base(str)
        {
            int letNumber = 0;
            foreach (char c in _string) if (Char.IsLetter(c)) letNumber++;
            char[] letters = new char[letNumber];
            for(int i = 0, j = 0; i < str.Length; i++) if (Char.IsLetter(_string[i])) letters[j++] = _string[i];
        }
        public LetterString():base(){}
        

        public string SortAlphabetical()
        {
            char[] tempStr = _string;
            Array.Sort(tempStr);
            return new string(tempStr);
        }
    }
}