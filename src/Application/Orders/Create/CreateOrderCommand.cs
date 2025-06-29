namespace Application.Orders.Create;

public record CreateOrderCommand(CreateOrderDto CreateOrderDto) : IRequest<long>;