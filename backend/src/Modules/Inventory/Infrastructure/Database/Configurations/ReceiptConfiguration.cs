using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseManagement.Modules.Inventory.Domain;

namespace WarehouseManagement.Modules.Inventory.Infrastructure.Database.Configurations;

public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    {
        builder.ToTable("Receipts", "inventory");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.ReferenceNumber).HasMaxLength(50).IsRequired();

        // Enum'ı string olarak tut (Draft, Completed vs. diye yazar, okunması kolay olur)
        builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasMany(r => r.Lines)
            .WithOne() // Eğer ReceiptLine içinde "public Receipt Receipt" yoksa parantez içi boş kalır.
            .HasForeignKey(l => l.ReceiptId)
            .IsRequired();// Fiş silinirse satırları da silinsin

        builder.HasOne<Supplier>()
            .WithMany()
            .HasForeignKey(r => r.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}