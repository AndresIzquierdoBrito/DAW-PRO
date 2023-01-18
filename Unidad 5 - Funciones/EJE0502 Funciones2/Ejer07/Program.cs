namespace Ejer07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Introduce primero una cadena y despues un caracter a buscar su cantidad de apariciones dentro de dicha cadena");
            string? introducedString = Console.ReadLine();
            char introducedChar = Funciones.CharValue();

            Console.WriteLine($"La cantidad de veces que aparece el caracter {introducedChar} en la string introducida es: {Funciones.AmountOfCharAppearances(introducedString, introducedChar)}");
        }
    }
}