using BattleShip.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Coordinate> Coordinates { get; }
        IRepository<Field> Fields { get; }
        IRepository<Game> Games { get; }
        IRepository<Move> Moves { get; }
        IRepository<Player> Players { get; }
        IRepository<PlayerGame> PlayerGames { get; }
        IRepository<Ship> Ships { get; }
        void Save();
    }
}
