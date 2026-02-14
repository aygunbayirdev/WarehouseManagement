using MediatR;
using WarehouseManagement.Modules.Inventory.Domain;

namespace WarehouseManagement.Modules.Inventory.Application.Suppliers.CreateSupplier;

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Guid>
{
    private readonly ISupplierRepository _repository;

    public CreateSupplierCommandHandler(ISupplierRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var supplier = new Supplier(request.Name, request.ContactName, request.PhoneNumber);

        await _repository.AddAsync(supplier, cancellationToken);

        return supplier.Id;
    }
}