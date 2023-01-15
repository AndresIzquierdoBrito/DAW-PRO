internal class Program
{
    private static void Main(string[] args)
    {
        string cadena, aux = "";
        char caracter;
        int n;

        Console.WriteLine("Introduce una cadena:");
        cadena = Console.ReadLine();
        Console.WriteLine("Introduce un caracter de la cadena:");
        caracter = Convert.ToChar(Console.ReadLine());
        Console.WriteLine("Introduce un valor:");
        n = Convert.ToInt32(Console.ReadLine());    

        for (int i = 0; i < cadena.Length; i++) 
        {
            aux = 
            if (cadena[i] == caracter)
            {
                for (int k = n; k > 0; k--)
                    aux += caracter;
                i += n;
                aux = " " + aux;
            }
        }
        Console.WriteLine(aux);
    }
}