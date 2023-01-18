using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer07
{
    internal class Funciones
    {
        public static int AmountOfCharAppearances(string introducedString, char charToFind)
        {
            int cont = 0;
            foreach (char ch in introducedString)
                if (ch == charToFind) cont++;

            return cont;
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
