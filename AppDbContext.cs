
using IproxTvMazeTest.model;
using Microsoft.EntityFrameworkCore;

namespace IproxTvMazeTest
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=iprox_db;User Id=user;Password=secret;");
        }

        public DbSet<Show> Shows { get; set; }
    }
}
