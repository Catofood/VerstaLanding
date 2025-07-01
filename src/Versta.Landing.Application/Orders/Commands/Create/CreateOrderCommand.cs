namespace Versta.Landing.Application.Orders.Commands.Create;

public record CreateOrderCommand(CreateOrderDto CreateOrderDto) : IRequest<long>;