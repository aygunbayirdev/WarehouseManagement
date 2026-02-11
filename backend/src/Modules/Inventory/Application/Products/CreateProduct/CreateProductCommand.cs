using MediatR;

namespace WarehouseManagement.Modules.Inventory.Application.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    string BaseUnit,
    int CategoryId,
    int TrackingStrategy) : IRequest<Guid>;