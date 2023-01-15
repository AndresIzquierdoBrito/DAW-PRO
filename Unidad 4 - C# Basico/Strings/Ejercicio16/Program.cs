using System.Threading.Channels;

internal class Program
{
    private static void Main(string[] args)
    {
        string cadena;
        int i = 0, j = 0;
        bool esPalindromo = true;

        Console.WriteLine("Introduce una cadena de texto:");
        cadena = Console.ReadLine();
        j = cadena.Length - 1;

        while (i < j && esPalindromo) {
            if (cadena[i] == cadena[j])
                esPalindromo = false;
            else
            {
                i++;
                j--;
            }
        }
        if (esPalindromo) Console.WriteLine("Es palíndromo.");
        else Console.WriteLine("La cadena no es palíndroma");

    }
}