using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Modules.Inventory.Application.Categories.CreateCategory;

namespace WarehouseManagement.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        var command = new CreateCategoryCommand(request.Name);
        var categoryId = await _mediator.Send(command);
        return Ok(new { Id = categoryId });
    }

    public record CreateCategoryRequest(string Name);
}