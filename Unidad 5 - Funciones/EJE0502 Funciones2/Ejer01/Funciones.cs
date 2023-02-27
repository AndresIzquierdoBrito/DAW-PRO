
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer01
{
    internal class Funciones
    {
        private static void SortArr(int[] arr) => Array.Sort(arr);

        public static int LowerNumb(int[] arr)
        {
            SortArr(arr);
            return arr[0];
        }
        public static int FillVectorRecursion(int[] arr, int numb = 0)
        {
            arr[numb] = IntValue();
            return numb == arr.Length - 1 ? 0 : FillVectorRecursion(arr, numb + 1);
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
