using MediatR;
using WarehouseManagement.Modules.Inventory.Domain;

namespace WarehouseManagement.Modules.Inventory.Application.Receipts.CreateReceipt;

public class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, Guid>
{
    private readonly IReceiptRepository _repository;

    public CreateReceiptCommandHandler(IReceiptRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
    {
        var receipt = new Receipt(request.SupplierId, request.ReferenceNumber);

        foreach (var lineDto in request.Lines)
        {
            receipt.AddLine(lineDto.ProductId, lineDto.Quantity);
        }

        await _repository.AddAsync(receipt, cancellationToken);

        return receipt.Id;
    }
}