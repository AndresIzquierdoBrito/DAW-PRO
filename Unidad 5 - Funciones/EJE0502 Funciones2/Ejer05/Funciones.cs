
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer05
{
    internal class Funciones
    {
        public static int amountDigits(int num)
        {
            int i = 1, cont = 0;
            while (Convert.ToInt32(num / (Math.Pow(10, i))) != 0)
            {
                i++;
                cont++;
            }
            return cont;
        }
        public static int IntValue()
        {
            int returnedInt;
            while (!Int32.TryParse(Console.ReadLine(), out returnedInt))
                Console.WriteLine("Valor no válido. Valor esperado: ENTERO");
            return returnedInt;
        }
    }
}
