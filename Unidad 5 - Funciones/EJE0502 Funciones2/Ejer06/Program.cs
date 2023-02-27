using Ejer06;

internal class Program
{
    private static void Main(string[] args)
    {
        int amountValues = 10;
        decimal[] array = new decimal[amountValues];
        Functions.FillDecimalAray(ref array, amountValues);
        Console.WriteLine($"El array queda asi: {string.Join(", ", array)}");
        Console.WriteLine($"Media aritmetica de los valores de la array: {Functions.CalculateAvg(array)}");
    }
}