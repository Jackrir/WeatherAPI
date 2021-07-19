using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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

            modelBuilder.Entity<City>().HasData(
                new City { Name = "Kharkiv", CurrentTemperature = 23, AverageTemperature = 24.5, MaxTemperature = 33, MinTemperature = 15 },
                new City { Name = "Kiev", CurrentTemperature = 29, AverageTemperature = 29, MaxTemperature = 36, MinTemperature = 23 },
                new City { Name = "Lviv", CurrentTemperature = 28, AverageTemperature = 25, MaxTemperature = 38, MinTemperature = 23 }
                );

            modelBuilder.Entity<Measure>().HasData(
                new Measure { CityName = "Kharkiv", Time = Convert.ToDateTime("2021-07-19T09:00:00.441"), Temperature = 15, ArchiveStatus = false },
                new Measure { CityName = "Kharkiv", Time = Convert.ToDateTime("2021-07-19T12:00:00.441"), Temperature = 26, ArchiveStatus = false },
                new Measure { CityName = "Kharkiv", Time = Convert.ToDateTime("2021-07-19T15:00:00.441"), Temperature = 33, ArchiveStatus = false },
                new Measure { CityName = "Kharkiv", Time = Convert.ToDateTime("2021-07-19T18:00:00.441"), Temperature = 23, ArchiveStatus = false },
                new Measure { CityName = "Kharkiv", Time = Convert.ToDateTime("2021-07-19T19:00:42.676"), Temperature = 10, ArchiveStatus = true },
                new Measure { CityName = "Kharkiv", Time = Convert.ToDateTime("2021-07-19T19:10:42.676"), Temperature = 20, ArchiveStatus = true },
                new Measure { CityName = "Kiev", Time = Convert.ToDateTime("2021-07-19T09:00:00.441"), Temperature = 23, ArchiveStatus = false },
                new Measure { CityName = "Kiev", Time = Convert.ToDateTime("2021-07-19T12:00:00.441"), Temperature = 28, ArchiveStatus = false },
                new Measure { CityName = "Kiev", Time = Convert.ToDateTime("2021-07-19T15:00:00.441"), Temperature = 36, ArchiveStatus = false },
                new Measure { CityName = "Kiev", Time = Convert.ToDateTime("2021-07-19T18:00:00.441"), Temperature = 29, ArchiveStatus = false },
                new Measure { CityName = "Lviv", Time = Convert.ToDateTime("2021-07-19T09:00:00.441"), Temperature = 23, ArchiveStatus = false },
                new Measure { CityName = "Lviv", Time = Convert.ToDateTime("2021-07-19T12:00:00.441"), Temperature = 24, ArchiveStatus = false },
                new Measure { CityName = "Lviv", Time = Convert.ToDateTime("2021-07-19T15:00:00.441"), Temperature = 28, ArchiveStatus = false },
                new Measure { CityName = "Lviv", Time = Convert.ToDateTime("2021-07-19T18:00:00.441"), Temperature = 27, ArchiveStatus = true }
                );
        }
    }
}
