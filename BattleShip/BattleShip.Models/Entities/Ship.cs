using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Models.Entities
{
    public class Ship
    {
        public int Id { get; set; }
        public int Size { get; set; }

        public List<Coordinate> Coordinates { get; set; }
        public int? FieldId { get; set; }
        public Field Field { get; set; }
    }
}
