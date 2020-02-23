using System;
using  TextAbstractionLab2;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stringy s1 = new Stringy(new char[] {'s','t','r','i','n','g','1','2','3'});
            Stringy s2 = new Stringy(new char[] {'s','t','r','i','n','g','2','3','3','4'});
            Stringy s3 = new Stringy(new char[] {'s','t','r','i','n','g','5','4','8','d','8','3','c','4'});
            
            Texty text = new Texty(new Stringy[] {s1,s2,s3}, 3);
            
            char[] l = text.GetLongestString();
            Console.WriteLine(l);

            for(int i = 0; i < text.Size; i++){
                Console.WriteLine(text.Strings[i].Symbols);
            }
            Console.WriteLine();

            text.DeleteString(2);
            for(int i = 0; i < text.Size; i++){
                Console.WriteLine(text.Strings[i].Symbols);
            }

            Console.WriteLine(text.GetLength());
            Console.WriteLine(text.GetDigitsPercentage());

            text.ClearText();

        }
    }
}