using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SecondAppSums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10, num2 = 15;   //Declare and initialize both functions
            int totalSum = num1 + num2; //Decleare and initialize the totalSum with the actual sum
            Console.Write($"La suma de {num1} y de {num2} es {totalSum}");
            Console.ReadKey();
        }
    }
}
