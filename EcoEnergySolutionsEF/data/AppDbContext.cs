using System.Collections.Generic;
using System.Net;
using EcoEnergySolutionsEF.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EcoEnergySolutionsEF.data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Simulacio> Simulacio { get; set; }
        public DbSet<EnergyIndicator> EnergyIndicator { get; set; }
        public DbSet<WaterConsumption> WaterConsumption { get; set; }

        //Constructor necessari per injecció de dependencies
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        }
    }
}
