using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calcular media de altura.\nIntroduce la cantidad de personas a tratar:");
            int numPersonas = Validated.IntValue();
            Personas[] listaPersonas = CSFunciones.LeerDatosMuestra(numPersonas);

            int menuOption;
            Console.Clear();
            do
            {
                Console.WriteLine("[1] Mostrar todas las personas.\n[2] Mostrar personas por encima de la media.\n[3] Mostrar personas por debajo de la media.\n[4] Salir.");
                menuOption = Validated.IntValue();
                switch (menuOption)
                {
                    case 1: CSFunciones.MostrarDatosMuestra(listaPersonas); break;
                    case 2: CSAlturas.MostrarPersonas(CSAlturas.PersonasPorEncimaMedia(listaPersonas)); break;
                    case 3: CSAlturas.MostrarPersonas(CSAlturas.PersonasPorDebajoMedia(listaPersonas)); break;
                    default: Console.WriteLine("No es una opción valida."); break;
                }
            } while (menuOption != 4);
        }
    }
}
