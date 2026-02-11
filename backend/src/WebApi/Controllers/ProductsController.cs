using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Modules.Inventory.Application.Products.CreateProduct;

namespace WarehouseManagement.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
    {
        var command = new CreateProductCommand(request.Name, request.BaseUnit, request.CategoryId, request.TrackingStrategy);

        var productId = await _mediator.Send(command);

        return Ok(new { Id = productId });
    }
}

public record CreateProductRequest(string Name, string BaseUnit, Guid categoryId, int TrackingStrategy)