using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProPair
{
    public struct Personas
    {
        public string nombre;
        public string apellidos;
        public decimal altura;
    }
    internal class CSFunciones
    {
        public static int SolicitarNumerosPersonas()
        {
            Console.WriteLine("Introduce la cantidad de personas a tratar: (ENTERO)");
            return Validated.IntValue();
        }
        public static Personas[] LeerDatosMuestra(int personasMuestra)
        {
            Personas[] datosPersonas = new Personas[personasMuestra];
            for (int i = 0; i < personasMuestra; i++)
            {
                Console.Write("\nNombre:");
                datosPersonas[i].nombre = Validated.Name();
                Console.Write("Apellidos:");
                datosPersonas[i].apellidos = Console.ReadLine();
                Console.Write("Altura (Valor positivo | Limite altura: 3M):");
                datosPersonas[i].altura = Validated.DecimalValue(true, 3);
            }

            return datosPersonas;
        }
        public static void MostrarDatosMuestra(Personas[] listaPersonas)
        {
            //for (int i = 0; i < listaPersonas.Length; i++)
            //{
            //    Console.WriteLine($"Nombre de persona[{i}]: {listaPersonas[i].nombre}");
            //    Console.WriteLine($"Apellido de persona[{i}]: {listaPersonas[i].apellidos}");
            //    Console.WriteLine($"Altura de persona[{i}]: {listaPersonas[i].altura}\n");
            //}
            int i = 0;
            foreach (Personas persona in listaPersonas)
            {
                Console.WriteLine($"Nombre de persona[{i}]: {persona.nombre}");
                Console.WriteLine($"Apellido de persona[{i}]: {persona.apellidos}");
                Console.WriteLine($"Altura de persona[{i}]: {persona.altura}\n");
                i++;
            }

        }
    }
    internal class Validated
    {
        public static int IntValue() //Pedir numero entero validado
        {
            int returnedInt;
            while (!int.TryParse(Console.ReadLine(), out returnedInt))
            {
                Console.WriteLine("Value not valid. Expected value: INTEGER");
            }
            return returnedInt;
        }
        public static decimal DecimalValue(bool positive, int upperLimit) //Funcion reutilizable, pasandole en positive si quieres que sea positivo o negativo y en upperLimit el numero limite entero
        {//Odio esta funcion
            decimal returnedDecimal;
            bool decimalCheck, positiveCheck, limiteCheck;
            do
            {
                decimalCheck = false; positiveCheck = false; limiteCheck = false;
                if (Decimal.TryParse(Console.ReadLine(), out returnedDecimal))
                {
                    decimalCheck = true;
                    positiveCheck = (positive && returnedDecimal > 0) || !positive;

                    if (upperLimit == 0)
                        limiteCheck = true;
                    else
                        if (returnedDecimal <= upperLimit)
                        limiteCheck = true;
                }
            } while (!decimalCheck || !positiveCheck || !limiteCheck);
            return returnedDecimal;
        }
        public static string Name() //Funcion para verificar que un nombre introducido no esta vacio
        {
            string nameInput;
            do
            {
                nameInput = Console.ReadLine();
                if (nameInput.Trim().Length == 0)
                    Console.WriteLine("Nombre no valido. No puede estar vacío");
            } while (nameInput.Trim().Length == 0);
            return nameInput;
        }
    }
}
