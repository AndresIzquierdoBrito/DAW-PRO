using OOP_Practice;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        if (Ficheros.FileExists() && Ficheros.LoadFile())
        {
            Ficheros.CountryMenu();
        }
    }
}