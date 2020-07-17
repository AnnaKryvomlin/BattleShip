using BattleShip.DataAccess.EF;
using BattleShip.DataAccess.Interfaces;
using BattleShip.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.DataAccess.Repositories
{
    public class ShipRepository : IRepository<Ship>
    {
        private ApplicationDbContext db;

        public ShipRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public void Create(Ship item)
        {
            this.db.Ships.Add(item);
        }

        public void Delete(int id)
        {
            Ship item = this.db.Ships.Find(id);
            if (item == null)
                throw new Exception("Item with this Id doesn't exist");
            this.db.Ships.Remove(item);
        }

        public Ship Get(int id)
        {
            return this.db.Ships.Find(id);
        }

        public IEnumerable<Ship> GetAll()
        {
            return this.db.Ships;
        }

        public void Update(Ship item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }
    }
}
