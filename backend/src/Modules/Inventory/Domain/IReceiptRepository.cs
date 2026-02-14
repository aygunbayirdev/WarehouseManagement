using WarehouseManagement.Modules.Inventory.Domain;

namespace WarehouseManagement.Modules.Inventory.Domain;

public interface IReceiptRepository
{
    Task AddAsync(Receipt receipt, CancellationToken cancellationToken);
}