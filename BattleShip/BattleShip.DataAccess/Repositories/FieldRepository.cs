using BattleShip.DataAccess.EF;
using BattleShip.Models.Entities;
using BattleShip.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.DataAccess.Repositories
{
    public class FieldRepository : IRepository<Field>
    {
        private ApplicationDbContext db;

        public FieldRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public void Create(Field item)
        {
            this.db.Fields.Add(item);
        }

        public void Delete(int id)
        {
            Field item = this.db.Fields.Find(id);
            if (item == null)
                throw new Exception("Item with this Id doesn't exist");
            this.db.Fields.Remove(item);
        }

        public Field Get(int id)
        {
            return this.db.Fields.Find(id);
        }

        public IEnumerable<Field> GetAll()
        {
            return this.db.Fields;
        }

        public void Update(Field item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }
    }
}
