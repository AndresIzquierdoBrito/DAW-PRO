internal class Program
{
    private static void Main(string[] args)
    {
        string cadena = "";
        Console.WriteLine("Introduce una cadena: ");
        cadena = Console.ReadLine();

        for (int i = cadena.Length - 1; i >= 0; i--)
        {
            Console.Write(cadena[i]);
        }
        Console.ReadKey();
    }
}