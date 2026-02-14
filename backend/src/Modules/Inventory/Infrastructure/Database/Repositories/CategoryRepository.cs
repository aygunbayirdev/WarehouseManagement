using WarehouseManagement.Modules.Inventory.Domain;
using WarehouseManagement.Modules.Inventory.Infrastructure.Database;

namespace WarehouseManagement.Modules.Inventory.Infrastructure.Database.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly InventoryDbContext _context;

    public CategoryRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category, CancellationToken cancellationToken)
    {
        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}