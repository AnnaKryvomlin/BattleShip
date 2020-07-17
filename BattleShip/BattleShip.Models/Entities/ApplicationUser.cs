using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Models.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public Player Player { get; set; } 
    }
}
