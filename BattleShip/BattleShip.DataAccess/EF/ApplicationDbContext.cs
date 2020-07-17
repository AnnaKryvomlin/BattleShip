using BattleShip.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BattleShip.DataAccess.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerGame> PlayerGames { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Coordinate> Coordinates { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerGame>()
                .HasKey(t => new { t.PlayerId, t.GameId });

            modelBuilder.Entity<PlayerGame>()
                .HasOne(sc => sc.Player)
                .WithMany(s => s.PlayerGames)
                .HasForeignKey(sc => sc.PlayerId);

            modelBuilder.Entity<PlayerGame>()
                .HasOne(sc => sc.Game)
                .WithMany(c => c.PlayerGames)
                .HasForeignKey(sc => sc.GameId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
