using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Models.Entities
{
    public class Move
    {
        public int Id { get; set; }
        public string PlayerMove { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
