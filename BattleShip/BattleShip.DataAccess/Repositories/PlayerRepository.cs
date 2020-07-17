using BattleShip.DataAccess.EF;
using BattleShip.DataAccess.Interfaces;
using BattleShip.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.DataAccess.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private ApplicationDbContext db;

        public PlayerRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public void Create(Player item)
        {
            this.db.Players.Add(item);
        }

        public void Delete(int id)
        {
            Player item = this.db.Players.Find(id);
            if (item == null)
                throw new Exception("Item with this Id doesn't exist");
            this.db.Players.Remove(item);
        }

        public Player Get(int id)
        {
            return this.db.Players.Find(id);
        }

        public IEnumerable<Player> GetAll()
        {
            return this.db.Players;
        }

        public void Update(Player item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }
    }
}
