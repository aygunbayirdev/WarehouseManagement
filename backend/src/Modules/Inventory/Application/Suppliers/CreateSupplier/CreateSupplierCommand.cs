using MediatR;

namespace WarehouseManagement.Modules.Inventory.Application.Suppliers.CreateSupplier;

public record CreateSupplierCommand(
    string Name,
    string ContactName,
    string PhoneNumber) : IRequest<Guid>;