using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Container> Containers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Vehicle>().HasData
                (
                    new Vehicle { Id = 1, VehicleName = "Arac1", VehiclePlate = "06ANK001"},
                    new Vehicle { Id = 2, VehicleName = "Arac2", VehiclePlate = "06ANK002"}
                );

            modelBuilder.Entity<Container>().HasData(
            new Container() { Id = 1, ContainerName = "Cont1Antares", Latitude = 39.97m, Longitude = 32.8212m, VehicleId = 1 },
            new Container() { Id = 2, ContainerName = "Cont2TurgutOzalUni", Latitude = 39.9721m, Longitude = 32.8252m, VehicleId = 2 },
            new Container() { Id = 3, ContainerName = "Cont3AsagiEglence", Latitude = 39.9721m, Longitude = 32.8396m, VehicleId = 1 },
            new Container() { Id = 4, ContainerName = "Cont4RagipTParki", Latitude = 39.9657m, Longitude = 32.8121m, VehicleId = 2 },
            new Container() { Id = 5, ContainerName = "Cont5YenimahKaymakamlik", Latitude = 32.8121m, Longitude = 32.811m, VehicleId = 1 },
            new Container() { Id = 6, ContainerName = "Cont6IvedikMetro", Latitude = 39.9576m, Longitude = 32.8169m, VehicleId = 2 },
            new Container() { Id = 7, ContainerName = "Cont7DemetParki", Latitude = 39.9669m, Longitude = 32.7971m, VehicleId = 1 },
            new Container() { Id = 8, ContainerName = "Cont8NazimHikmetKültrMerkezi", Latitude = 39.9606m, Longitude = 32.7788m, VehicleId = 2 }
            );

        }

    }
}
