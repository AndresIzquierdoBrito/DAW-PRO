using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EXA0601
{
    public class Utils
    {
        public static void ShowMenu()
        {
            Console.WriteLine("Elija una de las siguientes opciones\n" +
                "1.- Alquilar juego\n" +
                "2.- Devolver juego\n" +
                "3.- Mostrar info tienda\n" +
                "4.- Mostrar historial\n" +
                "0.- Salir");
        }
        public static int IntValue(int lowerLimit = int.MinValue, int upperLimit = int.MaxValue)
        {
            int userInput;
            bool check = false;
            if (lowerLimit != int.MinValue && upperLimit != int.MaxValue)
                Console.Write(" entre " + lowerLimit + " y " + upperLimit);
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

        public static string ValidManagerName()
        {
            string name;
            bool valid = false;
            do
            {
                name = Console.ReadLine();
                if (name.Length < 3)
                    Console.WriteLine("El nombre no puede ser menor que tres caracteres");
                else
                    valid = true;
            } while (!valid);
            return name;
        }

        public static int ValidPhoneNumber()
        {
            bool valid = false;
            int phoneNumber;
            do {
                if (!int.TryParse(Console.ReadLine(), out phoneNumber))
                    Console.WriteLine("Telephone number must be an integer");
                else if (phoneNumber.ToString().Length != 9)
                    throw new ArgumentNullException(nameof(phoneNumber), "Telephone number must be 9 digits.");
                else if (phoneNumber.ToString().Substring(0, 3) != "922")
                    throw new ArgumentNullException(nameof(phoneNumber), "Telephone number must start with 922.");
            } while (!valid);

            return phoneNumber;
        }
    }
}
