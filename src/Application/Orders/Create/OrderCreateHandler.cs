namespace Application.Orders.Create;

public class OrderCreateHandler : IRequestHandler<OrderCreateCommand, Unit>
{
    public async Task<Unit> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        
        throw new NotImplementedException();
    }
}