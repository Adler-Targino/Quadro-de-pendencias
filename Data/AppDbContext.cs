using Microsoft.EntityFrameworkCore;
using Quadro_de_pendencias.Models;

namespace Quadro_de_pendencias.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<BoardModel> Boards => Set<BoardModel>();
        public DbSet<GroupModel> Groups => Set<GroupModel>();
        public DbSet<CardModel> Cards => Set<CardModel>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardModel>()
                .HasMany(x => x.Groups)
                .WithOne(x => x.Board)
                .HasForeignKey(x => x.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupModel>()
                .HasMany(x => x.Cards)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}