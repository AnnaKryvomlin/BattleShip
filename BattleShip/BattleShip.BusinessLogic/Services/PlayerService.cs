using BattleShip.BusinessLogic.Interfaces;
using BattleShip.DataAccess.Interfaces;
using BattleShip.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.BusinessLogic.Services
{
    public class PlayerService : IPlayerService
    {
        private IUnitOfWork db;

        public PlayerService(IUnitOfWork uow)
        {
            this.db = uow;
        }

        public void CreatePlayer(ApplicationUser user)
        {
            Player player = new Player();
            player.Id = user.Id;
            player.UserName = user.UserName;
            db.Players.Create(player);
            db.Save();
        }

        public Player FindPlayer(int id)
        {
            return db.Players.Get(id);
        }
    }
}