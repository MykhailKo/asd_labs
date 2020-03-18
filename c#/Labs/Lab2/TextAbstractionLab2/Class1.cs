using System;
using System.Linq;

namespace TextAbstractionLab2
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

    public class Texty
    {
        private Stringy[] _strings = { };
        private int _size = 0;
        private int _digits = 0;
        private int _length = 0;

        public Texty(Stringy[] strings, int size)
        {
            _size = size;
            _strings = strings;
            for (int i = 0; i < _strings.Length; i++)
            {
                _length += _strings[i].GetLength();
                _digits += _strings[i].GetDigits();
            }
        }

        public Texty()
        {
            _strings = new Stringy[0];
        }

        public void AddString(Stringy s)
        {
            _size += 1;
            _length += s.GetLength();
            _digits += s.GetDigits();
            Stringy[] tempStrings = _strings;
            _strings = new Stringy[_size];
            for (int i = 0; i < _size; i++)
            {
                if (i < _size - 1) _strings[i] = tempStrings[i];
                else _strings[i] = s;
            }
        }

        public char[] GetLongestString()
        {
            int longest = 0;
            for (int i = 0; i < _size; i++)
            {
                if (_strings[i].GetLength() > _strings[longest].GetLength()) longest = i;
            }

            return _strings[longest].GetSymbols();
        }

        public bool DeleteString(int index)
        {
            if (index > (_size - 1)) return false;
            for (int i = index; i < _size; i++)
            {
                if (i == _size - 1) continue;
                else _strings[i] = _strings[i + 1];
            }

            _size -= 1;
            return true;
        }

        public void ClearText()
        {
            _size = 0;
            _length = 0;
            _digits = 0;
            _strings = null;
        }

        public Stringy[] GetStrings()
        {
            return _strings;
        }

        public int GetLength()
        {
            return _length;
        }

        public int GetSize()
        {
            return _size;
        }

        public double GetDigitsPercentage()
        {
            return (_digits * 100 / _length);
        }
    }
}