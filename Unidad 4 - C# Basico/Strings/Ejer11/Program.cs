internal class Program
{
    private static void Main(string[] args)
    {
        string cadena = "", palabra = "";
        int j = 0;
        string espacio = " ";

        Console.WriteLine("Introduce una cadena:");
        cadena = Console.ReadLine();

        for (int i = 0; i < cadena.Length; i++)
        {
            j++;
            if (cadena[i] == ' ')
            {
                Console.WriteLine(j);
            }


        }

    }
}