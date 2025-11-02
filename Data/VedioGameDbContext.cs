using Microsoft.EntityFrameworkCore;
using VedioGameAPI.Model;

namespace VedioGameAPI.Data
{
    public class VedioGameDbContext(DbContextOptions<VedioGameDbContext> options) : DbContext(options)
    {
        public DbSet<VedioGame> VedioGames => Set<VedioGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VedioGame>().HasData(
                new VedioGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Nintendo Switch", Developer = "Nintendo", Publisher = "Nintendo" },
                new VedioGame { Id = 2, Title = "God of War", Platform = "PlayStation 4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
                new VedioGame { Id = 3, Title = "Red Dead Redemption 2", Platform = "PlayStation 4, Xbox One, PC", Developer = "Rockstar Games", Publisher = "Rockstar Games" }
                );
        }

    }
}
