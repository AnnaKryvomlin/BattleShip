using BattleShip.DataAccess.EF;
using BattleShip.Models.Entities;
using BattleShip.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private CoordinateRepository coordinateRepository;
        private FieldRepository fieldRepository;
        private GameRepository gameRepository;
        private MoveRepository moveRepository;
        private PlayerGameRepository playerGameRepository;
        private PlayerRepository playerRepository;
        private ShipRepository shipRepository;

        public UnitOfWork(DbContextOptions<ApplicationDbContext> options)
        {
            this.db = new ApplicationDbContext(options);
        }

        public IRepository<Coordinate> Coordinates
        {
            get
            {
                if (coordinateRepository == null)
                    coordinateRepository = new CoordinateRepository(db);
                return coordinateRepository;
            }
        }

        public IRepository<Field> Fields
        {
            get
            {
                if (fieldRepository == null)
                    fieldRepository = new FieldRepository(db);
                return fieldRepository;
            }
        }

        public IRepository<Game> Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(db);
                return gameRepository;
            }
        }

        public IRepository<Move> Moves
        {
            get
            {
                if (moveRepository == null)
                    moveRepository = new MoveRepository(db);
                return moveRepository;
            }
        }

        public IRepository<PlayerGame> PlayerGames
        {
            get
            {
                if (playerGameRepository == null)
                    playerGameRepository = new PlayerGameRepository(db);
                return playerGameRepository;
            }
        }

        public IRepository<Player> Players 
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepository(db);
                return playerRepository;
            }
        }
        
        public IRepository<Ship> Ships
        {
            get
            {
                if (shipRepository == null)
                    shipRepository = new ShipRepository(db);
                return shipRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
