using BattleShip.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.WEB.Models
{
    public class ShipViewModel
    {
        public int Size { get; set; }

        public List<Coordinate> Coordinates { get; set; }
    }
}
