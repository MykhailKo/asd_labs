using System;
using StringsLab5;
using FiguresLab5;

namespace Lab5Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LetterString ms1 = new LetterString(new[] {'a', 'h', 'c', '1', 'n', '2', '/'});
            LetterString ms2 = new LetterString();
            
            Console.WriteLine(ms1.Val);
            Console.WriteLine(ms2.Val);
            Console.WriteLine(ms1.SortAlphabetical());

            Figure f1, f2;
            f1 = new Ellipse(2,3);
            f2 = new Circle(2);
            Console.WriteLine(f1.getArea());
            Console.WriteLine(f1.getPerimeter());
            Console.WriteLine(f2.getArea());
            Console.WriteLine(f2.getPerimeter());
        }
    }
}