using System;

namespace FiguresLab5
{
    public class Figure
    {
        public virtual double getPerimeter() => Double.NaN;
        public virtual double getArea() => Double.NaN;
    }

    public class Ellipse : Figure
    {
        private float SemiWidth { get; set; }
        private float SemiHeight { get; set; }

        public Ellipse()
        {
            SemiHeight = 1;
            SemiWidth = 1;
        }

        public Ellipse(float semiHeight, float semiWidth)
        {
            SemiHeight = semiHeight;
            SemiWidth = semiWidth;
        }
            
        public override double getPerimeter() => 2*Math.PI * Math.Sqrt((Math.Pow(SemiHeight, 2) + Math.Pow(SemiWidth, 2))/2);
        public override double getArea() => Math.PI * SemiHeight * SemiWidth;
    }

    public class Circle : Figure
    {
        private float Radius { get; set; }

        public Circle()
        {
            Radius = 1;
        }

        public Circle(float radius)
        {
            Radius = radius;
        }

        public override double getPerimeter() => 2 * Math.PI * Radius;
        public override double getArea() => Math.PI * Math.Pow(Radius, 2);
    }
}