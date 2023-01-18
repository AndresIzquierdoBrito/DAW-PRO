using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer02
{
    class Funciones
    {
        public static int IndexOfMin(int[] array)
        {
            int minValue = array[0];
            int minPos = -1;
            int pos = -1;

            foreach (int num in array)
            {
                pos++;

                if (num <= minValue)
                {
                    minValue = num;
                    minPos = pos;
                }
            }
            return minPos;
        }

        public static int IntValue()
        {
            int returnedInt;
            while (!Int32.TryParse(Console.ReadLine(), out returnedInt))
                Console.WriteLine("Valor no válido. Valor esperado: ENTERO");
            return returnedInt;
        }

        public static int FillVectorRec(int[] arr, int numb = 0)
        {
            arr[numb] = IntValue();
            return numb == arr.Length - 1 ? 0 : FillVectorRec(arr, numb + 1);
        }
       
    }
}