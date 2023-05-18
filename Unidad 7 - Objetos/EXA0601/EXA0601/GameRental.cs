using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXA0601
{
    internal class GameRental
    {
        private Game Game { get; set; }

        private bool Availability { get; set; }

        public GameRental() { }

        public GameRental(Game Game)
        {
            this.Game = Game;
            this.Availability = true;
        }

        public void SetGame(Game game) => this.Game = game;

        public Game GetGame() => this.Game;

        public void SetAvailability(bool IsAvailable) => this.Availability = IsAvailable;

        public bool GetAvailability() => this.Availability;

        public override string ToString() => $"{Game}";

    }
}
