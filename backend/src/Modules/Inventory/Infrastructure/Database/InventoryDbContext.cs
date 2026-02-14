using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Modules.Inventory.Domain;

namespace WarehouseManagement.Modules.Inventory.Infrastructure.Database;

public class InventoryDbContext : DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<ReceiptLine> ReceiptLines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // MODULAR MONOLITH İÇİN ALTIN KURAL:
        // Inventory modülünün tabloları inventory şeması altına (inventory.Products) açılsın
        // Böylece diğer modüllerle tablolar karışmaz.
        modelBuilder.HasDefaultSchema("inventory");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDbContext).Assembly);
    }
}
