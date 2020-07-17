using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Models.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int CurrentMovePlayerId { get; set; }

        public List<Move> Moves { get; set; }
        public List<Field> Fields { get; set; }
        public List<PlayerGame> PlayerGames { get; set; }

        public Game()
        {
            PlayerGames = new List<PlayerGame>();
        }
    }
}
