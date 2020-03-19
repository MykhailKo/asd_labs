using System;
using System.Linq;

namespace MyArrayLab3
{
    public class MyArray
    {
        private int _length;
        private int[][] _arrayValues;
        private int _elementsSum;

        public int Sum
        {
            get
            {
                return _elementsSum;
            }
        }

        public MyArray(int[][] array)
        {
            _arrayValues = array;
            _length = array.Length;
            for (int i = 0; i < _length; i++) {
                for (int j = 0; j < _arrayValues[i].Length; j++) {
                    _elementsSum += _arrayValues[i][j];
                }
            }
        }

        public MyArray()
        {
            _arrayValues = new int[][] {};
            _length = 0;
            _elementsSum = 0;
        }

        public void AddRow(int[] row)
        {
            int[][] temp = _arrayValues;
            _arrayValues = new int[_length + 1][];
            for (int i = 0; i < _length; i++)
            {
                _arrayValues[i] = temp[i];
            }
            _arrayValues[_length] = row;
            _length += 1;
            for (int i = 0; i < row.Length; i++)
            {
                _elementsSum += row[i];
            }
        }
        
        public bool DeleteRow(int index)
        {
            if (index >= _length || index < 0)
            {
                return false;
            }
            for (int i = 0; i < _arrayValues[index].Length; i++)
            {
                _elementsSum -= _arrayValues[index][i];
            }
            int[][] temp = _arrayValues;
            _length -= 1;
            _arrayValues = new int[_length][];
            for (int i = 0; i < _length; i++)
            {
                _arrayValues[i] = temp[i];
            }
            return true;
        }

        public double this[int index]
        {
            get
            {
                if (index >= _length || index < 0)
                {
                    return 0;
                }
                double sum = 0;
                for (int i = 0; i < _arrayValues[index].Length; i++)
                {
                    sum += (int)Math.Pow(_arrayValues[index][i], 2);
                }
                sum /= _arrayValues[index].Length;
                return Math.Sqrt(sum);
            }
        }
    }
}