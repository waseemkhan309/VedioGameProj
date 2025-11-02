using Microsoft.EntityFrameworkCore;
using VedioGameAPI.Model;

namespace VedioGameAPI.Data
{
    public class VedioGameDbContext(DbContextOptions<VedioGameDbContext> options) : DbContext(options)
    {
        public DbSet<VedioGame> VedioGames => Set<VedioGame>();

    }
}
