
using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        if (Ficheros.FileExists() && Ficheros.LoadFile())
        {
            Ficheros.ListSelectedData(Ficheros.CountryMenu(), Ficheros.YearMenu());
        }
        Console.ReadKey();
    }
}