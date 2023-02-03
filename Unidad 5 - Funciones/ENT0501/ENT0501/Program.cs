
using ENT0501;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] Casas; // Array donde se guardan nombres de las casas
        double[] Costo; // Array donde se guardan el precio de las casas
        int amountHouses;

        Console.WriteLine("Input the amount of houses to store\n=================================");
        amountHouses = Validated.IntValue(lowerLimit: 1, upperLimit: 30); //Limite de casas introducidas entre 10 y 30
        Casas = new string[amountHouses];
        Costo = new double[amountHouses];

        Functions.RequestHouseData(ref Casas, ref Costo); //Solicita nombre y coste de la casa
        List<int> housesBetweenLimit = Functions.GetHousesBetweenPrice(ref Costo); // Guardamos en una lista los indices de cada casa entre un limite pedido al usuario
        List<int> housesUnderPrice = Functions.GetHousesUnderPrice(ref Costo); // Guardamos en una lista los indices de cada casa bajo un precio pedido usuario

        Console.Write("Houses between the range introduced\n===================================\n");
        Functions.DisplayHousesList(housesBetweenLimit, ref Casas, ref Costo); //Esta funcion imprime las casas y su coste de la lista de indices que cumplen la condicion dada
        Console.Write("\nHouses under the price introduced\n===================================\n");
        Functions.DisplayHousesList(housesUnderPrice, ref Casas, ref Costo);
    }
}