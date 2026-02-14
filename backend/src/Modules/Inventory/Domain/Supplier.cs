using WarehouseManagement.Shared.Kernel;

namespace WarehouseManagement.Modules.Inventory.Domain;

public class Supplier : BaseEntity
{
    public string Name { get; set; }
    public string ContactName { get; set; }
    public string PhoneNumber { get; set; }

    public Supplier(string name, string contactName, string phoneNumber)
    {
        Id = Guid.NewGuid();
        Name = name;
        ContactName = contactName;
        PhoneNumber = phoneNumber;
    }
}