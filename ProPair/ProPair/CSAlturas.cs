using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPair
{
    internal class CSAlturas
    {
        public static string[] PersonasPorEncimaMedia(Personas[] listaPersonas)
        {
            int j = 0;
            decimal avg = AlturaMedia(listaPersonas);
            for (int i = 0; i < listaPersonas.Length; i++)
            {
                if (listaPersonas[i].altura > avg)
                    j++;
            }
            string[] nombres = new string[j];
            for (int i = 0; i < j; i++)
            {
                if (listaPersonas[i].altura > avg)
                    nombres[i] = listaPersonas[i].nombre;
            }
            return nombres;
        }
        public static string[] PersonasPorDebajoMedia(Personas[] listaPersonas)
        {
            int j = 0;
            for (int i = 0; i < listaPersonas.Length; i++)
            {
                if (listaPersonas[i].altura < AlturaMedia(listaPersonas))
                    j++;
            }
            string[] nombres = new string[j];
            for (int i = 0; i < j; i++)
            {
                if (listaPersonas[i].altura < AlturaMedia(listaPersonas))
                    nombres[i] = listaPersonas[i].nombre;
            }
            return nombres;
        }

        public static void MostrarPersonas(string[] personasFiltradas)
        {
            Console.WriteLine("Lista de nombres: ");
            for (int i = 0; i < personasFiltradas.Length; i++)
            {
                Console.WriteLine(personasFiltradas[i]);
            }
        }

        public static decimal AlturaMedia(Personas[] listaPersonas)
        {
            decimal avgHeight = 0;
            for (int i = 0; i < listaPersonas.Length; i++)
            {
                avgHeight += listaPersonas[i].altura;
            }
            return avgHeight/listaPersonas.Length;
        }
    }
}
