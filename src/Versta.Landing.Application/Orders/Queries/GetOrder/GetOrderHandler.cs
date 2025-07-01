using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Versta.Landing.Application.Interfaces;

namespace Versta.Landing.Application.Orders.Queries.GetOrder;

public class GetOrderHandler : IRequestHandler<GetOrderQuery, GetOrderDto>
{
    private readonly IOrdersDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetOrderHandler(IOrdersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<GetOrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var orderId = request.OrderId;
        var orderEntity = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken: cancellationToken);
        if (orderEntity is null) throw new KeyNotFoundException($"Order with {orderId} not found");
        var orderDto = _mapper.Map<GetOrderDto>(orderEntity);
        return orderDto;
    }
}