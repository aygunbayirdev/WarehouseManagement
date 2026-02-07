using WarehouseManagement.Shared.Kernel;

namespace WarehouseManagement.Modules.Inventory.Domain;

public class ProductVariant : BaseEntity
{
    public string Sku { get; private set; } // Benzersiz kod
    public string Name { get; private set; } // Örn: "iPhone 15 Siyah 128GB"
    public string? Gtin { get; private set; }
    public decimal PurchasePrice { get; private set; }
    public decimal SalesPrice { get; private set; }

    private ProductVariant() 
    {
        Sku = null!;
        Name = null!;
    }

    internal ProductVariant(string sku, string name, string? gtin, decimal purchasePrice, decimal salesPrice)
    {
        Sku = sku;
        Name = name;
        Gtin = gtin;
        PurchasePrice = purchasePrice;
        SalesPrice = salesPrice;
    }
}