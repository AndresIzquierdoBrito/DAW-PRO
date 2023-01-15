internal class Program
{
    private static void Main(string[] args)
    {
        string cadena = "", vocales = "";
        Console.WriteLine("Introduce una cadena: ");
        Console.ReadLine(cadena);

        if (cadena[0] == 'a')
            vocales += "[a] ";
        if (cadena.ToLower().Contains("e"))
            vocales += "[e] ";
        if (cadena.ToLower().Contains("i"))
            vocales += "[i] ";
        if (cadena.ToLower().Contains("o"))
            vocales += "[o] ";
        if (cadena.ToLower().Contains("u"))
            vocales += "[u] ";

        Console.WriteLine($"La cadena \"{cadena}\" contiene las siguiente(s) vocal/es

    }
}