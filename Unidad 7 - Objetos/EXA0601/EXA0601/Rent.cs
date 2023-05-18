using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EXA0601
{
    internal class Rent
    {
        private int CodUser { get; set; }

        private GameRental Game { get; set; }

        public Rent(int codUsuario, GameRental game)
        {
            CodUser = codUsuario;
            Game = game;
        }

        public void SetCodUsuario(int codUsuario)
        {
            if (codUsuario < 100 || codUsuario > 999)
                throw new ArgumentNullException(nameof(codUsuario), "User code has to be between 100 and 999 (INCLUDED)");
            this.CodUser = codUsuario;
        }

        public int GetCodUsuario() => CodUser;

        public void SetGame(GameRental game) => this.Game = game;
        
        public GameRental GetGame() => this.Game;

        public override string ToString() => $"{Game} -- Usuario que lo tiene: {CodUser}";
    }
}
