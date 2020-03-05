using System;

namespace StringyLab2
{
    public class Stringy
    {
        private int _size = 0;
        private char[] _symbols = { };

        public Stringy(char[] s)
        {
            _symbols = s;
            _size = _symbols.Length;
        }

        public Stringy()
        {
            _symbols = new char[0];
        }

        public void AddChar(char c)
        {
            //_symbols.Append();
            _size += 1;
            char[] tempSymbols = _symbols;
            _symbols = new char[_size];
            for (int i = 0; i < _size; i++)
            {
                if (i < _size - 1) _symbols[i] = tempSymbols[i];
                else _symbols[i] = c;
            }
        }

        public bool DeleteChar(int index)
        {
            if (index > (_size - 1)) return false;
            for (int i = index; i < _size; i++)
            {
                if (i == _size - 1) continue;
                else _symbols[i] = _symbols[i + 1];
            } 
            _size -= 1;
            return true;
        }

        public int GetDigits()
        {
            int digitsNum = 0;
            for (int i = 0; i < _symbols.Length; i++)
            {
                if (Char.IsDigit(_symbols[i])) digitsNum++;
            }

            return digitsNum;
        }

        public int GetLength()
        {
            return _size;
        }

        public char[] GetSymbols()
        {
            return _symbols;
        }
    }
}