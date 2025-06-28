using Application.Interfaces;
using Application.Orders.Mapping;
using Domain.Entities;

namespace Application.Orders.Create;

public class OrderCreateHandler : IRequestHandler<OrderCreateCommand, long>
{
    private readonly IOrdersDbContext _dbContext;

    public OrderCreateHandler(IOrdersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = request.OrderCreateDto.ToEntity();
        _dbContext.Orders.Add(orderEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return orderEntity.Id;
    }
}