using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videojuegos
{
    public class Game
    {
        private string name;

        private decimal price;

        private Genre genre;

        public Game(string name, decimal price, Genre genre)
        {
            this.name = name;
            this.price = price;
            this.genre = genre;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Genre Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public override string ToString()
        {
            return $"{name} {price} {genre}";
        }
    }
}
