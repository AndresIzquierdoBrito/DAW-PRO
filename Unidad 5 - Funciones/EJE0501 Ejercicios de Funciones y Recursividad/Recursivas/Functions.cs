using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursivas
{
    internal class Functions
    {
        // Ejercicio 6
        public static void PrintNumbers(int n)
        {
            if (n <= 100)
            {
                Console.WriteLine(n);
                PrintNumbers(n + 1);
            }
            
        }
        public static string PrintNumbersUntil100String(int n)
        {
            if (n > 100)
            {
                return "";
            }
            return n + " " + PrintNumbersUntil100String(n + 1);
        }
        public static string PrintNumbersUntil100Reverse(int n)
        {
            if (n > 100)
            {
                return "";
            }
            return PrintNumbersUntil100Reverse(n + 1) + " " + n ;
        }
        // Ejercicio 7
        public static bool IsPrime(int n, int i = 2)
        {
            if (n <= 2)
                return n == 2;
            if (n % i == 0)
                return false;
            if (i > Math.Sqrt(n))
                return true;
            return IsPrime(n, i + 1);
        }

        // Ejercicio 8

        public static int letras(string s, char c, int index = 0)
        {
            if (index >= s.Length)
                return 0;
            int i = 0;
            if (s[index] == c)
                i = 1;
            
            return i + letras(s, c, index + 1);
          
        }

    }
}
