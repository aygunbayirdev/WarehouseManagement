using MediatR;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Modules.Inventory.Application.Receipts.CreateReceipt;

namespace WarehouseManagement.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReceiptsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReceiptsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReceiptRequest request)
    {
        var command = new CreateReceiptCommand(request.SupplierId, request.ReferenceNumber, request.Lines);
        var receiptId = await _mediator.Send(command);
        return Ok(new { Id = receiptId });
    }
}

public record CreateReceiptRequest(
    Guid SupplierId,
    string ReferenceNumber,
    List<ReceiptLineDto> Lines
);