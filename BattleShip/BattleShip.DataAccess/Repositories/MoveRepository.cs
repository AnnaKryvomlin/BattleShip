using BattleShip.DataAccess.EF;
using BattleShip.Models.Entities;
using BattleShip.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.DataAccess.Repositories
{
    public class MoveRepository : IRepository<Move>
    {
        private ApplicationDbContext db;

        public MoveRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public void Create(Move item)
        {
            this.db.Moves.Add(item);
        }

        public void Delete(int id)
        {
            Move item = this.db.Moves.Find(id);
            if (item == null)
                throw new Exception("Item with this Id doesn't exist");
            this.db.Moves.Remove(item);
        }

        public Move Get(int id)
        {
            return this.db.Moves.Find(id);
        }

        public IEnumerable<Move> GetAll()
        {
            return this.db.Moves;
        }

        public void Update(Move item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }
    }
}
