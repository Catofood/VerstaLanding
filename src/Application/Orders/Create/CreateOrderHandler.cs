using Application.Interfaces;
using Application.Orders.Mapping;
using Domain.Entities;

namespace Application.Orders.Create;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, long>
{
    private readonly IOrdersDbContext _dbContext;

    public CreateOrderHandler(IOrdersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = request.CreateOrderDto.ToEntity();
        _dbContext.Orders.Add(orderEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return orderEntity.Id;
    }
}