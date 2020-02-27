using System;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = -1, n2 = 1;

            bool isEqual = is_Equal(n1, n2);
            Console.WriteLine(isEqual);

            bool res;
            is_Equal(n1, n2, out res);
            Console.WriteLine(res);
            
            int n = 12;

            int resI = Increment(n);
            Console.WriteLine(resI);

            int resI2;
            Increment(n, out resI2);
            Console.WriteLine(resI2);
        }

        static int Increment(int a)
        {
            int size = Marshal.SizeOf(a)*8;
            for(int shift = 0; shift < (size - 1); shift++){
                a ^= 1 << shift;
                int temp_res = ((a >> shift) & 1) ^ 0;
                if(temp_res != 0) break;
            }
            return a;
        }

        static void Increment(int a, out int res)
        {
            int size = Marshal.SizeOf(a)*8;
            for(int shift = 0; shift < (size - 1); shift++){
                a ^= 1 << shift;
                int temp_res = ((a >> shift) & 1) ^ 0;
                if(temp_res != 0) break;
            }
            res = a;
        }

        static bool is_Equal(int a, int b){
            int size = Marshal.SizeOf(a)*8;
            for(int shift = size - 1; shift >= 0; shift--){
                if(Convert.ToBoolean(((a >> shift) & 1) ^ ((b >> shift) & 1))) return false;
            }
            return true;
        }

        static void is_Equal(int a, int b, out bool res){
            int size = Marshal.SizeOf(a)*8;
            res = true;
            for(int shift = size - 1; shift >= 0; shift--){
                if(Convert.ToBoolean(((a >> shift) & 1) ^ ((b >> shift) & 1))) {
                    res = false;
                    break;
                };
            }
        }
    }
}