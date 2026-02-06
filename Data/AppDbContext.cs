using Microsoft.EntityFrameworkCore;
using FoodApi.Modules;
using FoodApi.Data.Configurations;

namespace FoodApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        { 
        }

        // DbSet'ler
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // Model konfigürasyonlarını uygula
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ayrı configuration sınıflarını uygula
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
