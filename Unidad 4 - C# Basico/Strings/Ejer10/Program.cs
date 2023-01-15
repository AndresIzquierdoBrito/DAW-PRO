using System.Diagnostics.Tracing;

internal class Program
{
    private static void Main(string[] args)
    {
        string cadena, palabra;

        Console.WriteLine("Introduce una cadena: ");
        cadena = Console.ReadLine();
        Console.WriteLine("Introduce una palabra: ");
        palabra = Console.ReadLine();

        for (int i = 0; i < cadena.Length; i++)
        {
            if (palabra[0] == cadena[i])
            {
                for (int j = 0; j < cadena.Length; j++)
                {

                }
            }
        }

    }
}