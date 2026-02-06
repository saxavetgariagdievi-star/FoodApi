using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FoodApi.Modules;

namespace FoodApi.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Primary Key
            builder.HasKey(p => p.Id);

            // Properties
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Description)
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ProductTotal)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ImgUrl)
                   .HasMaxLength(300);

            // Many-to-Many için (opsiyonel)
            // builder.HasMany(p => p.Categories)
            //        .WithMany(c => c.Products)
            //        .UsingEntity(j => j.ToTable("ProductCategories"));
        }
    }
}
