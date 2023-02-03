using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ENT0501
{
    internal class Functions
    {
        public static void RequestHouseData(string[] Casas, double[] Costo) //Solicita un nombre de casa unico y un costo positivo de la cantidad de casas introducidas
        {
            Console.Clear();
            for (int i = 0; i < Casas.Length; i++)
            {
                Console.WriteLine($"Houses remaining: {Casas.Length - i}");
                Console.WriteLine($"Input the name of the house #{i}: ");
                Casas[i] = GetHouseName(ref Casas);
                Costo[i] = Validated.DoubleValue("Input the price of the house in EURO, price has to be", positiveOnly: true);
                Console.Clear();
            }
        }
        private static string GetHouseName(ref string[] Casas) // Valido que el nombre no esta vacio y no se reptire previamente, privada ya que es solo utilizada dentro de la clase
        {
            string? name;
            bool check;
            do
            {
                check = true;
                name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) // Revisa que el nombre no esta vacio/sea nulo
                {
                    check = false;
                    Console.WriteLine("Input cannot be empty");
                }
                for (int i = 0; i < Casas.Length; i++)
                {
                    if (name.Equals(Casas[i], StringComparison.CurrentCultureIgnoreCase))  // En vez de utilizar una simple comparacion boleana (usando ToLower), con este metodo excluyo la diferencia de minus/mayus
                    {
                        check = false;
                        Console.WriteLine("You cannot introduce an already used name for a house.");
                    }
                }
            } while (!check);
            return name;
        }
        public static List<int> GetHousesBetweenPrice(double[] Costo) 
            /* Pide un limite superior y un limite inferior para despues guardar en una lista
               los indices de las casas que se encuentran dentro de este rango. */
        {
            List<int> housesBetween = new List<int>();
            Console.Clear();
            double lowerLimit = Validated.DoubleValue("Lower limit of house cost");
            double upperLimit = Validated.DoubleValue("Upper limit of house cost");

            for (int i = 0; i < Costo.Length; i++)
            {
                if (Costo[i] >= lowerLimit && Costo[i] <= upperLimit)
                {
                    housesBetween.Add(i);
                }
            }
            return housesBetween;
        }
        public static List<int> GetHousesUnderPrice(double[] Costo) // Crea una lista con los indices de las casas por debajo de un valor pedido al usuario
        {
            List<int> housesUnder = new List<int>();
            Console.Clear();
            double underPrice = Validated.DoubleValue("Introduce a maximum house price");

            for (int i = 0; i < Costo.Length; i++) 
            {
                if (Costo[i] < underPrice) // Si una casa esta por debajo de underPrice, se guarda el indice en la lista
                {
                    housesUnder.Add(i);
                }
            }
            return housesUnder;
        }
        public static void DisplayHousesList(List<int> Houses, string[] Casas, double[] Costo) // Muestra por pantalla el indice, nombre y coste de la lista de valores enteros
        {
            for (int i = 0; i < Houses.Count; i++)
            {
                Console.WriteLine($"Casa #{Houses[i]}: {Casas[i]}\t{Costo[i]} euros");
            }
        }
    }
    internal class Validated
    {
        public static int IntValue(int lowerLimit = int.MinValue, int upperLimit = int.MaxValue) 
            /* Defino dos parametros para definir el rango de valores, al asingarles MaxValue/MinValue, 
               si no se le pasa un numero no hay limite (mas alla del limite de memoria de int) */
        {
            int userInput;
            Console.Write("Enter an integer");
            if (lowerLimit != int.MinValue && upperLimit != int.MaxValue)
            {
                Console.Write(" between " + lowerLimit + " and " + upperLimit);
            }
            Console.WriteLine(":");
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < lowerLimit || userInput > upperLimit) //Valida si es entero y si esta dentro de los limites, mostrando errores
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                }
                else if (userInput < lowerLimit || userInput > upperLimit)
                {
                    Console.WriteLine("Input value not within the specified range. Enter a new value between " + lowerLimit + " and " + upperLimit + ":");
                }
            }
            return userInput;
        }
        public static double DoubleValue(string promptMessage, bool positiveOnly = false)
            /* Defino dos parametros, promptMessage para darle un mensaje customizado de entrada de valor,
               y positiveOnly que, al ser true, solo pasa valores positive. */
        {
            double userInput;
            Console.Write(promptMessage);
            if (positiveOnly)
            {
                Console.Write(" greater than or equal to 0");
            }
            Console.WriteLine(":");
            while (!Double.TryParse(Console.ReadLine().Replace(',', '.'), out userInput) || (positiveOnly && userInput < 0)) // Hago un replace de , por . para siempre guardar el valor sin importar el separador
            {
                Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
            }
            return userInput;
        }
    }
}
