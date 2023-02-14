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
            decimal avg = AlturaMedia(listaPersonas);
            for (int i = 0; i < listaPersonas.Length; i++)
            {
                if (listaPersonas[i].altura < avg)
                    j++;
            }
            string[] nombres = new string[j];
            for (int i = 0; i < j; i++)
            {
                if (listaPersonas[i].altura < avg)
                    nombres[i] = listaPersonas[i].nombre;
            }
            return nombres;
        }

        public static void MostrarPersonas(string[] personasFiltradas)
        {
            Console.WriteLine("Lista de nombres: ");            
            foreach (string persona in personasFiltradas)
                Console.WriteLine(persona);
        }

        public static decimal AlturaMedia(Personas[] listaPersonas)
        {
            decimal avgHeight = 0;
            //for (int i = 0; i < listaPersonas.Length; i++)//foreach
            //{
            //    avgHeight += listaPersonas[i].altura;
            //}
            foreach (Personas persona in listaPersonas)
                avgHeight += persona.altura;

            return avgHeight/listaPersonas.Length;
        }
    }
}
