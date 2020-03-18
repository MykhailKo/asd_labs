using System;
using System.Linq;

namespace MyArrayLab3
{
    public class MyArray
    {
        private int _height;
        private int[][] _matrixValues;
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
            _matrixValues = array;
            _height = array.Length;
            for (int i = 0; i < _height; i++) {
                for (int j = 0; j < _matrixValues[i].Length; j++) {
                    _elementsSum += _matrixValues[i][j];
                }
            }
        }

        public MyArray()
        {
            _matrixValues = new int[][] {};
            _height = 0;
            _elementsSum = 0;
        }

        public double this[int index]
        {
            get
            {
                if (index >= _height || index < 0)
                {
                    return 0;
                }
                double sum = 0;
                for (int i = 0; i < _matrixValues[index].Length; i++)
                {
                    sum += (int)Math.Pow(_matrixValues[index][i], 2);
                }
                sum /= _matrixValues[index].Length;
                return Math.Sqrt(sum);
            }
        }
    }
}