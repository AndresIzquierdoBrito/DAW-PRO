using ENT0506;
using System.Text;

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