using Application.Interfaces;
using Application.Orders.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Get.Single;

public class GetOrderHandler : IRequestHandler<GetOrderQuery, GetOrderDto>
{
    private readonly IOrdersDbContext _dbContext;

    public GetOrderHandler(IOrdersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetOrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var orderId = request.OrderId;
        var orderEntity = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken: cancellationToken);
        if (orderEntity is null) throw new KeyNotFoundException($"Order with {orderId} not found");
        var orderDto = orderEntity.ToDto();
        return orderDto;
    }
}