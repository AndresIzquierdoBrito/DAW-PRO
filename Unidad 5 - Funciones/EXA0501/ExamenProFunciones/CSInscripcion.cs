using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProFunciones
{
    public struct Persona
    {
        public string nombre;
        public int copiasPagadas;
    }
    internal class CSInscripcion
    {

        public static Persona[] GetStudentsData()
        {
            Console.Clear();
            Persona[] studentsData = new Persona[2];
            int i = 0;
            bool check = false;
            string endCheck = "fin";
            do
            {
                Console.WriteLine("Introduce 'FIN' in name to end the data inputting.");
                studentsData[i].nombre = GetNames(studentsData);
                if (studentsData[i].nombre.ToLower() != endCheck)
                {
                    studentsData[i].copiasPagadas = IntValue(lowerLimit: 10);
                    i++;
                    Array.Resize(ref studentsData, i + 1);
                }
                else check = true;
                Console.Clear();
            } while (!check);
            Array.Resize(ref studentsData, i);
            return studentsData;
        }


        public static int IntValue(int lowerLimit = int.MinValue)
        /* Defino dos parametros para definir el rango de valores, al asingarles MaxValue/MinValue, 
           si no se le pasa un numero no hay limite (mas alla del limite de memoria de int) */
        {
            int userInput;
            Console.Write("\nEnter an integer");
            if (lowerLimit != int.MinValue)
            {
                Console.Write(" higher or equal to " + lowerLimit);
            }
            Console.WriteLine(":");
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < lowerLimit) //Valida si es entero y si esta dentro de los limites, mostrando errores
            {
                if (int.TryParse(userInput.ToString(), out int value))
                {
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                }
                else if (userInput < lowerLimit)
                {
                    Console.WriteLine("Input value not within the specified range. Enter a new value higher or equal to " + lowerLimit + ":");
                }
            }
            return userInput;
        }
        public static string GetNames(Persona[] names) // Valido que el nombre no esta vacio y no se reptire previamente, privada ya que es solo utilizada dentro de la clase
        {
            string? name;
            bool check;
            do
            {
                check = true;
                Console.Write("\n\tName: (UNIQUE): ");
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) // Revisa que el nombre no esta vacio/sea nulo
                {
                    check = false;
                    Console.WriteLine("Input cannot be empty");
                }
                for (int i = 0; i < names.Length; i++)
                {
                    if (name.Equals(names[i].nombre, StringComparison.CurrentCultureIgnoreCase))  // En vez de utilizar una simple comparacion boleana (usando ToLower), con este metodo excluyo la diferencia de minus/mayus
                    {
                        check = false;
                        Console.WriteLine("You cannot introduce an already stored name.");
                    }
                }
            } while (!check);
            return name;
        }
    }
}
