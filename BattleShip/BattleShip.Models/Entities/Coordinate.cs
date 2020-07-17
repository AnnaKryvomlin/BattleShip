using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Models.Entities
{
    public class Coordinate
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Mark { get; set; }

        public int FieldId { get; set; }
        public Field Field { get; set; }
        public int? ShipId { get; set; }
        public Ship Ship { get; set; }

        public Coordinate()
        {
            this.Mark = false;
        }
    }
}
