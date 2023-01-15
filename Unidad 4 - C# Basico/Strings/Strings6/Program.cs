internal class Program
{
    private static void Main(string[] args)
    {
        string cadena = "", vocales = "aeiou";
        int count = 0;
        Console.WriteLine("Introduce una cadena: ");
        cadena = Console.ReadLine();

        for(int i = 0; i < cadena.Length; i++)
            for(int j = 0; j < vocales.Length; j++)
                if (cadena[i] == vocales[j])
                    count++;
            
        
        Console.WriteLine($"La cadena \"{cadena}\" tiene {count} vocales.");
        Console.ReadKey();
    }
} 