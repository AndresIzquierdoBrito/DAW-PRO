using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer07
{
    internal class Funciones
    {
        public static int[] AmountPosCharAppearances(string? input, char ch)
        {
            input += " ";
            int[] values = new int[input.Split(ch).Length];
            values[0] = values.Length - 1;
            for (int i = 0, j = 1; i < input.Length; i++)
            {
                if (ch == input[i])
                {
                    values[j] = i;
                    j++;
                }
            }
            //foreach (char ch in input) MANCO, NO PARA CONSEGUIR POSICIONES DE ARRAY
            //{
            //    if (ch == ch)
            //        values[j] = i;
            //    i++;
            //}
            return values;
        }

        public static char CharValue()
        {
            bool check = false;
            char returnedChar;
            do
            {
                if (char.TryParse(Console.ReadLine(), out returnedChar))
                    check = true;
                else
                    Console.WriteLine("Valor no válido. Valor esparado: CHAR");
            } while (!check);

            return returnedChar;
        }
    }
}
