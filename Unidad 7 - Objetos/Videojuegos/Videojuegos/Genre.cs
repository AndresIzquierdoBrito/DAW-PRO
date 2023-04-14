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

        private int minAge;


        public string Name
        {
            get { return name ?? throw new ArgumentNullException(nameof(name)); }
            set { name = value; }
        }

        public int MinAge
        {
            get { return minAge; }
            set { minAge = value; }
        }

        public Genre(string name, int age)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.MinAge = age;
        }
  

        public static Genre ChooseGenre(List<Genre> genres)
        {
            int choice, maxAmountChoice = genres.Count;

            Console.WriteLine("Available genres: (Minimum age)");
            for (int i = 0; i < maxAmountChoice; i++)
                Console.WriteLine($"{i + 1}. {genres[i].Name} ({genres[i].MinAge})");

            do
            {
                Console.WriteLine("Enter the number corresponding to the desired genre: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxAmountChoice);

            return genres[choice - 1];
        }

        public override string ToString()
        {
            return $"{name} {minAge}";
        }
    }

    
}
