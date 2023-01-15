internal class Program
{
    private static void Main(string[] args)
    {
        string cadena = "", cadena2 = "";
        Console.WriteLine("Introduce una cadena: ");
        cadena = Console.ReadLine();

        for(int i = cadena.Length - 1; i >= 0; i--)
        {
            cadena2 += cadena[i];
        }
        Console.WriteLine(cadena2);
        Console.ReadKey();
    }
}