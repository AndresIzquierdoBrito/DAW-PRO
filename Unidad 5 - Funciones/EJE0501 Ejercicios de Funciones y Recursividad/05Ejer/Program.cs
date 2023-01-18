namespace Ejer05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string pila = "";
            int option;
            bool check = false;
            Console.WriteLine("Introduce un primer dato en la pila: ");
            pila += Funciones.CharValue();
            Console.Clear();
            while (!check)
            {
                Console.WriteLine("PILA DE DATOS\nRealiza una accion: \n\t[x]Opción 1: Introducir dato a la pila \n\t[x]Opción 2: Extraer dato de la pila\n\t[x]Opción 3: Visualizar datos de la pila");
                Console.WriteLine("Para salir del programa, vacia la pila de datos.");
                Console.Write("Selecciona una opción:");

                option = Funciones.GetOptionWitinBounds();

                switch (option)
                {
                    case 1:
                        Funciones.IntroducirDatosPila(ref pila);
                        break;
                    case 2:
                        Funciones.ExtraerDatosPila(ref pila);
                        break;
                    case 3:
                        Funciones.VisualizarPila(pila);
                        break;
                }
                if (pila.Length == 0)
                    Console.WriteLine("La pila de datos esta vacia. El programa ha finalizado.");
                    check = true;

            }
        }
    }
    internal class Funciones
    {
        public static string IntroducirDatosPila(ref string pila)
        {
            Console.Clear();
            Console.WriteLine("Inroduccion de dato");
            Console.Write("Caracter: ");
            char c = CharValue();
            return pila += c;
        }
        public static string ExtraerDatosPila(ref string pila)
        {
            Console.Clear();
            Console.WriteLine($"Dato extraido: {pila[0]}");
            return pila = pila.Remove(0,1); 

        }
        public static void VisualizarPila(string pila)
        {
            Console.Clear();
            Console.WriteLine("Contenido de la pila: \n▄▄▄▄");
            foreach (char c in pila)
            {
                Console.WriteLine($"▌ {c} ▌");
            }
            Console.WriteLine("▄▄▄▄");
        }
        public static int GetOptionWitinBounds()
        {
            int option;
            bool check = false;
            do
            {
                option = IntValue();
                if (option != 1 || option != 2 || option != 3)
                    check = true;
                else
                    Console.WriteLine("Selecciona una de las opciones dispnibles. (1 | 2 | 3)");
            } while (!check);
            return option;
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
        public static int IntValue()
        {
            bool check = false;
            int returnedInt;
            do
            {
                if (int.TryParse(Console.ReadLine(), out returnedInt))
                    check = true;
                else Console.WriteLine("Valor no válido. Valor esperado: ENTERO");
            } while (!check);

            return returnedInt;
        }
    }
}