internal class Program
{
    private static void Main(string[] args)
    {
        string cadena = "";
        char letra;
        int sum = 0;
        Console.WriteLine("Introduce una cadena: ");
        cadena = Console.ReadLine();
        Console.WriteLine("Introduce una letra: ");
        if (char.TryParse(Console.ReadLine(), out letra))
        {
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena[i] == letra)
                    sum++;
            }
        }
        Console.WriteLine($"Cantidad de veces que [{letra}] aparece en \"{cadena}\": {sum}");
        Console.ReadKey();
    }
}