using System;
using Microsoft.EntityFrameworkCore;
using MonitoringSystemBlazorShared;

namespace MonitoringSystemBlazorApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Habitat> Habitats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Animal Data
            modelBuilder.Entity<Animal>().HasData(new Animal
            {
                Id = 1,
                Type = AnimalType.Lion,
                Name = "Leo",
                Age = 5,
                HealthConcerns = "Cut on left front paw",
                FeedingSchedule = "Twice daily"
            });

            modelBuilder.Entity<Animal>().HasData(new Animal()
            {
                Id = 2,
                Type = AnimalType.Tiger,
                Name = "Maj",
                Age = 15,
                HealthConcerns = "",
                FeedingSchedule = "3x per day"
            });

            modelBuilder.Entity<Animal>().HasData(new Animal()
            {
                Id = 3,
                Type = AnimalType.Bear,
                Name = "Baloo",
                Age = 1,
                HealthConcerns = "",
                FeedingSchedule = ""
            });

            modelBuilder.Entity<Animal>().HasData(new Animal()
            {
                Id = 4,
                Type = AnimalType.Giraffe,
                Name = "Spots",
                Age = 12,
                HealthConcerns = "",
                FeedingSchedule = "Grazing"
            });

            // Seed Habitat Data
            modelBuilder.Entity<Habitat>().HasData(new Habitat()
            {
                Id = 1,
                Name = "Penguin",
                Temp = Temperature.Freezing,
                FoodSource = "Fish in water running low",
                IsClean = true
            });

            modelBuilder.Entity<Habitat>().HasData(new Habitat()
            {
                Id = 2,
                Name = "Bird",
                Temp = Temperature.Moderate,
                FoodSource = "Natural from environment",
                IsClean = true
            });

            modelBuilder.Entity<Habitat>().HasData(new Habitat()
            {
                Id = 3,
                Name = "Aquarium",
                Temp = Temperature.Varied,
                FoodSource = "Added daily",
                IsClean = false
            });
        }
    }
}