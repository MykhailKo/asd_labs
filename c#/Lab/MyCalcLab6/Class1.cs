using System;

namespace MyCalcLab6
{
    public class MyCalc
    {
        private double _a, _c, _d;
        public double ArgA
        {
            get { return _a;}
            set
            {
                if (_c + value == 1) throw new DivideByZeroException(
                            "The sum of a and c in denominator must be different from 1 to avoid division by 0!");
                ArgA = value;
            }
            
        }

        public double ArgC
        {
            get { return _c;}
            set
            {
                if (ArgA + value == 1) throw new DivideByZeroException(
                            "The sum of a and c in denominator must be different from 1 to avoid division by 0!");
                ArgC = value;
            }
        }

        public double ArgD
        {
            get { return _d;}
            set
            {
                if(value == 0) throw new DivideByZeroException("Argument d cannot be 0 to avoid division by 0!");
                if(value < 0) throw new ArgumentException("A number under the square root must be bigger than 0, d must be bigger than 0!");
                _d = value;
            } 
        }

        public MyCalc(double a, double c, double d)
        {
            if(c + a == 1) throw new DivideByZeroException("The sum of a and c in denominator must be different from 1 to avoid division by 0!");
            _a = a;
            _c = c;
            ArgD = d;
        }

        public double Calculate() 
        {
            return (2 * ArgC - ArgD * Math.Sqrt(42 / ArgD)) / (ArgA + ArgC - 1);
        }
    }
}