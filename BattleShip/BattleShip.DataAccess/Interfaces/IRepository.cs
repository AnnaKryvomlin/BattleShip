﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.DataAccess.Interfaces
{
    public interface IRepository<T>
            where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
