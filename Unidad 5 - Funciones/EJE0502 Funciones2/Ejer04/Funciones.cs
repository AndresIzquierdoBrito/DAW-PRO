
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer04
{
    internal class Funciones
    {
        public static bool IsLeapYear(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
                return true;
            else
                return false;
        }
        public static int IntValue()
        {
            bool check = false;
            int returnedInt;
            do
            {
                if (int.TryParse(Console.ReadLine(), out returnedInt))
                    check = true;
                else Console.WriteLine("Valor no válido. Valor esperado: ENTERO");
            } while (!check);

            return returnedInt;
        }
    }
}
