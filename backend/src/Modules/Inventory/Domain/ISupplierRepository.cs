namespace WarehouseManagement.Modules.Inventory.Domain;

public interface ISupplierRepository
{
    Task AddAsync(Supplier supplier, CancellationToken cancellationToken);
    Task<Supplier?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}