using BattleShip.DataAccess.EF;
using BattleShip.DataAccess.Interfaces;
using BattleShip.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleShip.DataAccess.Repositories
{
    public class PlayerGameRepository : IRepository<PlayerGame>
    {
        private ApplicationDbContext db;

        public PlayerGameRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public void Create(PlayerGame item)
        {
            this.db.PlayerGames.Add(item);
        }

        public void Delete(int id)
        {
            PlayerGame item = this.db.PlayerGames.Find(id);
            if (item == null)
                throw new Exception("Item with this Id doesn't exist");
            this.db.PlayerGames.Remove(item);
        }

        public PlayerGame Get(int id)
        {
            return this.db.PlayerGames.Find(id);
        }

        public IEnumerable<PlayerGame> GetAll()
        {
            return this.db.PlayerGames.Include(pg => pg.Game);
        }

        public void Update(PlayerGame item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }
    }
}
