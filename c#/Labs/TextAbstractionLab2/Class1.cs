using System;

namespace TextAbstractionLab2
{
    public class Stringy
    {
        public char[] Symbols = { };

        public Stringy(char[] s)
        {
            Symbols = s;
        }

        public int GetDigits()
        {
            int digitsNum = 0;
            for (int i = 0; i < Symbols.Length; i++)
            {
                if (Char.IsDigit(Symbols[i])) digitsNum++;
            }

            return digitsNum;
        }

        public int GetLength()
        {
            return Symbols.Length;
        }
    }

    public class Texty
    {
        public Stringy[] Strings = { };
        public int Size = 0;
        public int Digits = 0;
        public int Length = 0;

        public Texty(Stringy[] strings, int size)
        {
            Size = size;
            Strings = strings;
            for (int i = 0; i < Strings.Length; i++)
            {
                Length += Strings[i].GetLength();
                Digits += Strings[i].GetDigits();
            }
        }
        
        public char[] GetLongestString()
        {
            int longest = 0;
            for (int i = 0; i < Size; i++)
            {
                if (Strings[i].GetLength() > Strings[longest].GetLength()) longest = i;
            }

            return Strings[longest].Symbols;
        }

        public bool DeleteString(int index)
        {
            if (index > (Size - 1)) return false;
            for (int i = index; i < Size; i++)
            {
                if (i == Size - 1) Strings[i] = null;
                else Strings[i] = Strings[i + 1];
            } 
            Size -= 1;
            return true;
        }

        public void ClearText()
        {
            Size = 0;
            Length = 0;
            Digits = 0;
            Strings = null;
        }

        public int GetLength()
        {
            return Length;
        }

        public double GetDigitsPercentage()
        {
            return (Digits * 100 / Length);
        }
    }
}