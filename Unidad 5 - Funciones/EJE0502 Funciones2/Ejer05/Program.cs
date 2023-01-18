using Ejer05;

internal class Program
{
    private static void Main(string[] args)
    {
        int num;
        Console.WriteLine("Introduce un valor entero:");
        do
        {
            num = Funciones.IntValue();
            if (num < 0) 
                Console.WriteLine("El valor introducido no puede ser menor o igual que 0.");
        } while (num < 0);

        Console.WriteLine($"El numero {num} tiene {Funciones.amountDigits(num)} digitos.");
    }
}