namespace WarehouseManagement.Modules.Inventory.Domain;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Product product, CancellationToken cancellationToken = default);
    void Update(Product product);
    void Delete(Product product);
    Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);
}