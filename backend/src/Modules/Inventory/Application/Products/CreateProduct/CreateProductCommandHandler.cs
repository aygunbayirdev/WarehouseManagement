using MediatR;
using WarehouseManagement.Modules.Inventory.Application.Products.CreateProduct;
using WarehouseManagement.Modules.Inventory.Domain;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken = default)
    {
        var product = new Product(
            request.Name,
            request.BaseUnit,
            request.CategoryId,
            (TrackingStrategy)request.TrackingStrategy);

        await _repository.AddAsync(product, cancellationToken);

        return product.Id;        
    }
}