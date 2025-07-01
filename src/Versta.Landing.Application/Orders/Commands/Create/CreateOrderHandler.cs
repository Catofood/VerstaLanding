using AutoMapper;
using Versta.Landing.Application.Interfaces;
using Versta.Landing.Domain.Entities;

namespace Versta.Landing.Application.Orders.Commands.Create;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, long>
{
    private readonly IOrdersDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateOrderHandler(IOrdersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderEntity = _mapper.Map<Order>(request.CreateOrderDto);
        _dbContext.Orders.Add(orderEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return orderEntity.Id;
    }
}