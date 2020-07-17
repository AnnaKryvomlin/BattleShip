using BattleShip.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShip.WEB.Models
{
    public class PersonalAccountViewModel
    {
        public string UserName { get; set; }
        public List<Game> Games { get; set; } 
    }
}
