using Versta.Landing.Application.Common.Pagination;
using Versta.Landing.Application.Orders.Commands.Create;
using Versta.Landing.Application.Orders.Queries;
using Versta.Landing.Application.Orders.Queries.GetOrder;
using Versta.Landing.Application.Orders.Queries.GetPaginatedOrders;
using Microsoft.AspNetCore.Mvc;

namespace Versta.Landing.Api.Controllers;

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
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrderDto)
    {
        var command = new CreateOrderCommand(createOrderDto);
        var orderId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetOrder), new { orderId = orderId }, new { orderId = orderId });
    }

    [HttpGet]
    [Route("get/{orderId:long}")]
    public async Task<ActionResult<GetOrderDto>> GetOrder([FromRoute] long orderId)
    {
        var command = new GetOrderQuery(orderId);
        var order = await _mediator.Send(command);
        return Ok(order);
    }

    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<PaginatedList<GetOrderDto>>> GetAllOrders([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var command = new GetPaginatedOrdersQuery(page, pageSize);
        var paginatedOrders = await _mediator.Send(command);
        return Ok(paginatedOrders);
    }
}