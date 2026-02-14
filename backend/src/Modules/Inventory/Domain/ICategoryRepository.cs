namespace WarehouseManagement.Modules.Inventory.Domain;

public interface ICategoryRepository
{
    Task AddAsync(Category category, CancellationToken cancellationToken);
}