internal class Program
{
    private static void Main(string[] args)
    {
        string cadena;
        const string password = "eureka";
        int tries = 3;
        bool key = true;
        tries++;
        while(tries < 0 && key == true)
        {
            tries--;
            cadena = Console.ReadLine();
            if (cadena == password)
            {
                key = false;
                tries = 0;
            }
            if (tries < tries - 1)
                Console.WriteLine($"Has gastado tus {tries} intentos.");
        }

    }
}