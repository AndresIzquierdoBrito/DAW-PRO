using Videojuegos;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Game> games = new List<Game>();
        Genre.InitializeGenres();

        int menuOption;
        do
        {
            Console.Write("---------------- VIDEOGAME LIBRARY --------------------\n\t1. Add game.\n\t2. Remove game.\n\t3. Show game libray.\n\t4. Quit.\n\nSelect an option ");
            menuOption = Functions.IntValue(1, 4);
            switch (menuOption)
            {
                case 1:
                    Console.Clear();
                    Functions.AddGame(games);
                    break;

                case 2:
                    Console.Clear();
                    Functions.RemoveGame(games);
                    break;
                case 3:
                    Console.Clear();
                    Functions.ListAllGames(games);
                    break;
            }
        } while (menuOption != 4);
        Console.Clear();
        Console.WriteLine("Program exited");
        Console.ReadKey();
    }
}