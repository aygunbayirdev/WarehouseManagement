using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Modules.Inventory.Application.Suppliers.CreateSupplier;

namespace WarehouseManagement.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuppliersController : ControllerBase
{
    private readonly IMediator _mediator;

    public SuppliersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSupplierRequest request)
    {
        var command = new CreateSupplierCommand(request.Name, request.ContactName, request.PhoneNumber);
        var supplierId = await _mediator.Send(command);
        return Ok(new { Id = supplierId });
    }
}

public record CreateSupplierRequest(string Name, string ContactName, string PhoneNumber);