using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Modules.Inventory.Domain;

namespace WarehouseManagement.Modules.Inventory.Infrastructure.Database.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.BaseUnit).IsRequired().HasMaxLength(10);

        builder.Property(x => x.TrackingStrategy).IsRequired();

        builder.HasMany(x => x.Variants)
            .WithOne()
            .HasForeignKey("ProductId")
            .OnDelete(DeleteBehavior.Cascade); // ürün silinirse varyantları da silinsin

        // DDD Kapsülleme Ayarı:
        // EF Core, 'Variants' property'sine yazamaz (çünkü private set yok, sadece get var)
        // O yüzden ona "Arka plandaki _variants field'ını kullan" diyoruz.
        builder.Navigation(x => x.Variants)
            .UsePropertyAccessMode(PropertyAccessMode.Field);



    }
}