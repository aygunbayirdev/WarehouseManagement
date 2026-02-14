using MediatR;
using WarehouseManagement.Modules.Inventory.Domain;


namespace WarehouseManagement.Modules.Inventory.Application.Products.GetProducts;

public record GetProductsQuery : IRequest<List<ProductDto>>;

public record ProductDto(Guid Id, string Name, string BaseUnit);

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductRepository _repository;

    public GetProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        return products
            .Select(p => new ProductDto(p.Id, p.Name, p.BaseUnit))
            .ToList();
    }
}