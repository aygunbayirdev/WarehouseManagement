using WarehouseManagement.Shared.Kernel;

namespace WarehouseManagement.Modules.Inventory.Domain;

public class ReceiptLine : BaseEntity
{
    public Guid ReceiptId { get; private set; }
    public Guid ProductId { get; private set; }
    public decimal Quantity { get; private set; }

    public ReceiptLine(Guid receiptId, Guid productId, decimal quantity)
    {
        Id = Guid.NewGuid();
        ReceiptId = receiptId;
        ProductId = productId;
        Quantity = quantity;
    }
}