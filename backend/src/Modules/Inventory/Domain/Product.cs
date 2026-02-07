using WarehouseManagement.Shared.Kernel;

namespace WarehouseManagement.Modules.Inventory.Domain;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? BrandName { get; private set; }
    public int CategoryId { get; private set; }
    public string BaseUnit { get; private set; } = "Adet";
    public TrackingStrategy TrackingStrategy { get; private set; }

    // DDD kuralı : Koleksiyon dışarıdan manipüle edilemez!
    private readonly List<ProductVariant> _variants = new();
    public IReadOnlyCollection<ProductVariant> Variants => _variants.AsReadOnly();

    private Product() 
    {
        Name = null!;
    }

    public Product(string name, string? brandName, int categoryId, TrackingStrategy trackingStrategy)
    {
        Name = name;
        BrandName = brandName;
        CategoryId = categoryId;
        TrackingStrategy = trackingStrategy;
    }

    // Aggregate Root üzerinden varyant ekleme metodu
    public void AddVariant(string sku, string variantName, decimal purchasePrice, decimal salesPrice, string? gtin = null)
    {
        var variant = new ProductVariant(sku, variantName, gtin, purchasePrice, salesPrice);
        _variants.Add(variant);

        // İleride burada 'ProductVariantAddedEvent' fırlatacağız!
    }


}