using System;
using System.IO;
using MyCalcLab6;

namespace Lab6Console
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter file = new StreamWriter("exceptionLog.txt", true);
            try
            {
                MyCalc c2 = new MyCalc(2, 3, 4);
                //MyCalc c3 = new MyCalc(0, 1, 5);
                //MyCalc c4 = new MyCalc(1, 1, -2);
                MyCalc c5 = new MyCalc(1, 1, 0);
            }
            catch (DivideByZeroException exc)
            {
                Console.WriteLine(exc.Message);
                file.WriteLine(exc);
                file.WriteLine("----------------------");
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
                file.WriteLine(exc);
                file.WriteLine("----------------------");
            }
            finally
            {
                file.Close();
                Console.WriteLine("Revise your parameters.");
            }
        }
    }
}