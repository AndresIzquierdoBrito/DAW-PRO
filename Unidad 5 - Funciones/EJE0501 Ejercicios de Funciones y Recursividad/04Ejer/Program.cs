namespace Ejer05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Introduce primero una cadena y despues un caracter a buscar su cantidad de apariciones dentro de dicha cadena");
            string? introducedString = Console.ReadLine();
            char introducedChar = Funciones.CharValue();

            Console.WriteLine($"La cantidad de veces que aparece el caracter {introducedChar} en la string introducida es: {Funciones.AmountOfCharAppearances(introducedString , introducedChar)}");
        }
    }
    internal class Funciones
    {
        public static int AmountOfCharAppearances(string introducedString, char charToFind)
        {
            int cont = 0;
            foreach (char ch in introducedString)
                if(ch == charToFind) 
                    cont++;

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