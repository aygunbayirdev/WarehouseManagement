using MediatR;

namespace WarehouseManagement.Modules.Inventory.Application.Categories.CreateCategory;

public record CreateCategoryCommand(string Name) : IRequest<Guid>;