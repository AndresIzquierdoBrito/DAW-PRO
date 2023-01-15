using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicios_Condicionales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num;
            string value;
            Console.WriteLine("Escribe un numero: ");
            value = Console.ReadLine();
            if (double.TryParse(value, out num))
            {
                if (num < 10)
                    Console.WriteLine($"El numero {num} es MENOR que 10.");
                else if (num > 10)
                    Console.WriteLine($"El numero {num} es MAYOR que 10.");
                else
                {
                    Console.WriteLine("El numero es igual a 10.");
                }
            }
            else
                Console.WriteLine("El valor introucido no es valido.");
            Console.ReadKey();
        }
    }
}
