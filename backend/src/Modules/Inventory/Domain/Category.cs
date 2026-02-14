using WarehouseManagement.Shared.Kernel;

namespace WarehouseManagement.Modules.Inventory.Domain;

public class Category : BaseEntity
{
    public string Name { get; private set; }

    // Constructor (DDD kuralı: Private set, constructor ile zorunlu kıl)
    public Category(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}