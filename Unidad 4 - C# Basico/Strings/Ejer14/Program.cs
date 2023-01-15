using System.Runtime.Serialization.Formatters;

internal class Program
{
    private static void Main(string[] args)
    {
        string cadena;
        bool mostrar = false;
        Console.WriteLine("Introduce una cadena: ");
        cadena = Console.ReadLine();

        for (int i = 0; i < cadena.Length; i++)
        {
            if (cadena[i] != ' ')
                mostrar = true;

            if (mostrar)
                Console.Write(cadena[i]);
        }
    }
}