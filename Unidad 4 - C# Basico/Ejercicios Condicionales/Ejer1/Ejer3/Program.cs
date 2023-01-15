using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string valueA, valueB;
            Console.WriteLine("Introduce dos valores a dividir:");
            Console.Write("Dividendo: ");
            valueA = Console.ReadLine();
            Console.Write("Divisor: ");
            valueB = Console.ReadLine();

            if (double.TryParse(valueA, out double numA) && double.TryParse(valueB, out double numB))
            {
                Console.WriteLine($"{numA} / {numB} = {numA / numB:f2}");
            }
            else
                Console.WriteLine("Valores introducidos incorrectors.");
            Console.ReadKey();
        }
    }
}
