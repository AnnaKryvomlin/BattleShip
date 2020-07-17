using BattleShip.DataAccess.EF;
using BattleShip.Models.Entities;
using BattleShip.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.DataAccess.Repositories
{
    public class CoordinateRepository : IRepository<Coordinate>
    {
        private ApplicationDbContext db;

        public CoordinateRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public void Create(Coordinate item)
        {
            this.db.Coordinates.Add(item);
        }

        public void Delete(int id)
        {
            Coordinate item = this.db.Coordinates.Find(id);
            if (item == null)
                throw new Exception("Item with this Id doesn't exist");
            this.db.Coordinates.Remove(item);
        }

        public Coordinate Get(int id)
        {
            return this.db.Coordinates.Find(id);
        }

        public IEnumerable<Coordinate> GetAll()
        {
            return this.db.Coordinates
                .Include(c => c.Field)
                .Include(c => c.Ship);
        }

        public void Update(Coordinate item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }
    }
}
