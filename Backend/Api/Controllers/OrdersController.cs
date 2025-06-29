using Application.Orders.Create;
using Application.Orders.Get;
using Application.Orders.Get.Paginated;
using Application.Orders.Get.Single;
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
    public async Task<ActionResult<List<GetOrderDto>>> GetAllOrders([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var command = new GetPaginatedOrdersQuery(page, pageSize);
        var paginatedOrders = await _mediator.Send(command);
        return Ok(paginatedOrders);
    }
}