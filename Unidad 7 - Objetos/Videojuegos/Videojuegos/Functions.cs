using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videojuegos
{
    internal class Functions
    {
        public static List<Game> AddGame(List<Game> gameList)
        {
            string name = InputValidName();
            decimal price = InputDoubleValue(lowerLimit: 0, maxDecimalPlaces: 2);
            Genre genre = Genre.ChooseGenre();

            Game game = new Game(name, price, genre);
            gameList.Add(game);

            Console.Clear();
            Console.WriteLine("Game added succesfully");
            EndMethod();
            return gameList;
        }

        public static List<Game> RemoveGame(List<Game> gameList)
        {
            if (gameList.Count == 0)
                Console.WriteLine("There are currently no games in the library.");
            else
            {
                int choice, amountGames = gameList.Count;
                for (int i = 0; i < amountGames; i++)
                    Console.WriteLine($"{i + 1}. {gameList[i].Name}");

                do
                {
                    Console.Write("Enter the number corresponding to the desired game you want to remove: ");
                } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > amountGames);

                gameList.RemoveAt(choice - 1);

                Console.WriteLine("Game removed succesfully");
            }

            EndMethod();
            return gameList;
        }

        public static void ListAllGames(List<Game> gameList)
        {
            if (gameList.Count == 0)
                Console.WriteLine("There are currently no games in the library.");
            else
            {
                Console.WriteLine("Name\t\t\tPrice\t\t\tGenre\n===================================================================");
                foreach (Game game in gameList)
                    Console.WriteLine($"{game.Name}\t\t\t{game.Price}\t\t\t{game.Genre}");
            }
            EndMethod();
        }

        public static string InputValidName()
        {
            string? n;
            do
            {
                Console.Write("Name: ");
                n = Console.ReadLine()?.Trim();
                Console.Clear();
                if (string.IsNullOrWhiteSpace(n))
                {
                    Console.WriteLine("Invalid name, input again");
                }
            } while (string.IsNullOrWhiteSpace(n));
            return n;
        }


        public static int IntValue(int lowerLimit = int.MinValue, int upperLimit = int.MaxValue)
        /* Defino dos parametros para definir el rango de valores, al asingarles MaxValue/MinValue, 
           si no se le pasa un numero no hay limite (mas alla del limite de memoria de int) */
        {
            int userInput;
            bool check = false;
            if (lowerLimit != int.MinValue && upperLimit != int.MaxValue)
                Console.Write(" between " + lowerLimit + " and " + upperLimit);
            else if (lowerLimit != int.MinValue)
                Console.Write(" higher than " + lowerLimit);
            else if (upperLimit != int.MaxValue)
                Console.Write(" lower than " + upperLimit);
            Console.WriteLine(":");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                else if (userInput < lowerLimit || userInput > upperLimit)
                    Console.WriteLine("Input value not within the specified range. Enter a new value between " + lowerLimit + " and " + upperLimit + ":");
                else
                    check = true;
            } while (!check);
            return userInput;
        }

        public static decimal InputDoubleValue(decimal lowerLimit = decimal.MinValue, decimal upperLimit = decimal.MaxValue, int maxDecimalPlaces = int.MaxValue)
        {
            decimal userInput;
            bool check = false;
            Console.Write("Input a value");
            if (lowerLimit != decimal.MinValue && upperLimit != decimal.MaxValue)
                Console.Write(" between " + lowerLimit + " and " + upperLimit);
            else if (lowerLimit != decimal.MinValue && upperLimit == decimal.MaxValue)
                Console.Write(" higher than " + lowerLimit);
            else if (upperLimit != decimal.MaxValue && lowerLimit == decimal.MinValue)
                Console.Write(" lower than " + upperLimit);
            Console.WriteLine(":");

            do
            {
                string input = Console.ReadLine() ?? "";
                if (!decimal.TryParse(input, out userInput))
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                else if (userInput < lowerLimit || userInput > upperLimit)
                    Console.WriteLine($"Input value not within the specified range. Enter a new value between the accepted range:");
                else if (input.Contains(".") && input.Split('.')[1].Length > maxDecimalPlaces)
                    Console.WriteLine($"Input value cannot have more than {maxDecimalPlaces} decimal places. Enter a new value:");
                else
                    check = true;
            } while (!check);
            Console.Clear();
            return userInput;
        }

        public static void EndMethod()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
