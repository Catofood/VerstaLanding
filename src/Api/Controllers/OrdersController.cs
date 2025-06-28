using Application.Orders.Create;
using Application.Orders.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IMediator _mediator;

    public OrdersController(ILogger<OrdersController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderCreateDto)
    {
        var command = new OrderCreateCommand(orderCreateDto);
        var orderId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetOrder), new { orderId = orderId }, new { orderId = orderId });
    }

    [HttpGet]
    [Route("get/{orderId:long}")]
    public async Task<ActionResult<OrderGetDto>> GetOrder([FromQuery] long orderId)
    {
        throw new NotImplementedException();
    }
}