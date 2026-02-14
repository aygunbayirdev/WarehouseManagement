using WarehouseManagement.Modules.Inventory.Domain;

namespace WarehouseManagement.Modules.Inventory.Infrastructure.Database.Repositories;

public class ReceiptRepository : IReceiptRepository
{
    private readonly InventoryDbContext _context;

    public ReceiptRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Receipt receipt, CancellationToken cancellationToken)
    {
        await _context.Receipts.AddAsync(receipt, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}