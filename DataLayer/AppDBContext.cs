using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDBContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Measure> Measures { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(x => x.Measures)
                .WithOne(x => x.City)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Measure>()
                .HasKey(x => new { x.CityName, x.Time });
        }
    }
}
