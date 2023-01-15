using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string valueA, valueB;
            valueA = Console.ReadLine();
            valueB = Console.ReadLine();

            if (double.TryParse(valueA, out double numA) && double.TryParse(valueB, out double numB))
            {
                if (numA - numB < 0)
                    Console.WriteLine("La resta no puede dar negativo");
                else
                    Console.WriteLine($"{numA} - {numB} = {numA - numB}");
            }
            else
                Console.WriteLine("Valores introducidos incorrectos.");

            Console.ReadKey();
        }
    }
}
