internal class Program
{
    private static void Main(string[] args)
    {
        string cadena = "", vocales = "aeiou", aux = ""; 
        Console.WriteLine("Introduce una cadena: ");
        cadena = Console.ReadLine();

        for (int i = 0; i < cadena.Length; i++)
        {
            for (int j = 0; j < vocales.Length; j++)
            {
                if (cadena[i] == vocales[j])
                   aux += vocales[j] + " ";
            }
        }
        Console.WriteLine($"Contiene las vocales: {aux}");
    }
}