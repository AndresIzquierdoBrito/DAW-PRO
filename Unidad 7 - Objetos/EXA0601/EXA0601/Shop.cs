using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EXA0601
{
    internal class Shop
    {
        private string Manager { get; set; }

        private string TelephoneNumber { get; set; }

        private List<GameRental> Catalog { get; set; }

        private List<Rent> RentHistory { get; set; }

        private List<Rent> CurrentGamesRented { get; set; }
        public Shop(string managerName, int telNumber)
        {

            this.Catalog = new List<GameRental>();
            this.RentHistory = new List<Rent>();
            this.CurrentGamesRented = new List<Rent>();
            SetManager(managerName);
            SetTelephoneNumber(telNumber);
        }

        public void SetManager(string managerName)
        {
            if (managerName.Length < 3)
                throw new ArgumentNullException(nameof(managerName), "Product name cannot be shorter than 3 letters.");
            this.Manager = managerName;
        }

        public string GetManager() => this.Manager;

        public void SetTelephoneNumber(int telNumber)
        {
            string telNumberStr = telNumber.ToString();
            if (telNumberStr.Length != 9)
                throw new ArgumentNullException(nameof(telNumber), "Telephone number must be 9 digits.");
            else if (telNumberStr.Substring(0, 3) != "922")
                throw new ArgumentNullException(nameof(telNumber), "Telephone number must start with 922.");
            this.TelephoneNumber = telNumberStr;
        }

        public string GetTelephoneNumber() => this.TelephoneNumber;

        public void RentGame()
        {
            int user = Utils.IntValue(100, 999), chosenGame, i, catalogSize = Catalog.Count, catalogSizeRemaining = Catalog.Where(game => game.GetAvailability() == true).Count() - 1;
            GameRental gameToRent;
            if (CurrentGamesRented.FindIndex(game => game.GetCodUsuario() == user) == -1)
            {
                for (i = 0; i < catalogSize; i++)
                {
                    if (Catalog[i].GetAvailability())
                        Console.WriteLine($"juego [{i + 1}]{Catalog[i].GetGame()}");
                }
                chosenGame = Utils.IntValue(1, i);
                gameToRent = Catalog.Where(game => game.GetAvailability() == true).ElementAt(chosenGame - 1);
                Catalog.Find(game => game.Equals(gameToRent)).SetAvailability(false);
                CurrentGamesRented.Add(new(user, gameToRent));
            }
            else
                Console.WriteLine($"El usuario {user} ya tiene un juego alquilado"); 

        }

        public void ReturnGame()
        {
            int user = Utils.IntValue(100, 999);

            //CurrentGamesRented.Find(game => game.GetCodUsuario() == user)
        }

        public void ShowShopInfo()
        {
            Console.WriteLine($"Encargado de la tienda: {GetManager()}\nTelefono de la tienda: {GetTelephoneNumber()}\n\nJuegos disponibles:\n");
            int catalogSize = Catalog.Count, amountRentals = CurrentGamesRented.Count;

            for (int i = 0; i < catalogSize; i++)
                if (Catalog[i].GetAvailability())
                    Console.WriteLine(Catalog[i].GetGame());

            Console.WriteLine("\nJuegos Alquilados:");
            for (int i = 0; i < amountRentals; i++)
                if (!Catalog[i].GetAvailability())
                {
                    Console.WriteLine($"{CurrentGamesRented[i]}");
                }
        }

        public void ShowRentHistory()
        {
            
            //Console.WriteLine(n == "" ? "Invalid name, input again" : "");

        }

        public void CreateGameCatalog()
        {
            Catalog.Add(new(new Game("Tetris", 10.55m)));
            Catalog.Add(new(new Game("Space invaders", 5.99m)));
            Catalog.Add(new(new Game("Lemmings", 12m)));
            Catalog.Add(new(new Game("Pong", 3.49m)));
            Catalog.Add(new(new Game("Pac-Man", 19.99m)));
            Catalog.Add(new(new Game("Donkey Kong", 39.99m)));
            Catalog.Add(new(new Game("Mario Bros", 10m)));
            Catalog.Add(new(new Game("Breakout", 6.85m)));

        }
    }
}
