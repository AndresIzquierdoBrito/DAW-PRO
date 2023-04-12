using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videojuegos
{
    public class Genre
    {
        private string? name;

        private static List<Genre> genres = new List<Genre>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Genre(string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            genres.Add(this);
        }

        public static void InitializeGenres()
        {
            new Genre("Action");
            new Genre("Adventure");
            new Genre("Plataformers");
            new Genre("Shooter");
            new Genre("Horror");
            new Genre("Mystery");
            new Genre("RPG");
            new Genre("Sci-Fi");
            new Genre("Multiplayer Online Battle Arena");
            new Genre("Massively multiplayer Online");
        }

        public static Genre ChooseGenre()
        {
            int choice, maxAmountChoice = genres.Count;

            Console.WriteLine("Available genres:");
            for (int i = 0; i < maxAmountChoice; i++)
                Console.WriteLine($"{i + 1}. {genres[i].Name}");

            do
            {
                Console.WriteLine("Enter the number corresponding to the desired genre: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxAmountChoice);

            return genres[choice - 1];
        }
    }

    
}
