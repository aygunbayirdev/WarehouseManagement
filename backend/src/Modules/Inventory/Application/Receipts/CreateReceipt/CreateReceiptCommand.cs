using MediatR;

namespace WarehouseManagement.Modules.Inventory.Application.Receipts.CreateReceipt;

public record CreateReceiptCommand(
    Guid SupplierId,
    string ReferenceNumber,
    List<ReceiptLineDto> Lines
) : IRequest<Guid>;

public record ReceiptLineDto(Guid ProductId, decimal Quantity);