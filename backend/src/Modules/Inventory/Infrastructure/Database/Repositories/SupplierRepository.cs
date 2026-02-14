using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Modules.Inventory.Domain;

namespace WarehouseManagement.Modules.Inventory.Infrastructure.Database.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly InventoryDbContext _context;

    public SupplierRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Supplier supplier, CancellationToken cancellationToken)
    {
        await _context.Suppliers.AddAsync(supplier, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Supplier?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}