using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT0506
{
    internal class Functions
    {
        public static int IntValue(int lowerLimit = int.MinValue, int upperLimit = int.MaxValue)
        /* Defino dos parametros para definir el rango de valores, al asingarles MaxValue/MinValue, 
           si no se le pasa un numero no hay limite (mas alla del limite de memoria de int) */
        {
            int userInput;
            bool check = false;
            if (lowerLimit != int.MinValue && upperLimit != int.MaxValue)
                Console.Write(" between " + lowerLimit + " and " + upperLimit);
            Console.WriteLine(":");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                else if (userInput < lowerLimit || userInput > upperLimit)
                    Console.WriteLine("Input value not within the specified range. Enter a new value between " + lowerLimit + " and " + upperLimit + ":");
                else 
                    check = true;
            } while (!check);
            return userInput;
        }
    }
}
