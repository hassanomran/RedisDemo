using Microsoft.EntityFrameworkCore;
using RedisDemo.Data.Models.Car;

namespace RedisDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Car> cars{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2020 },
                new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 },
                new Car { Id = 3, Make = "Ford", Model = "Mustang", Year = 2021 },
                new Car { Id = 4, Make = "Chevrolet", Model = "Camaro", Year = 2022 },
                new Car { Id = 5, Make = "Tesla", Model = "Model 3", Year = 2023 }
            );
        }
    }
}
