using BattleShip.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.BusinessLogic.Interfaces
{
    public interface IPlayerService
    {
        public void CreatePlayer(ApplicationUser user);
        Player FindPlayer(int id);
    }
}
