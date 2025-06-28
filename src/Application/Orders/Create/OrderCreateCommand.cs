using Application.Orders.Dtos;

namespace Application.Orders.Create;

public record OrderCreateCommand(OrderCreateDto OrderCreateDto) : IRequest<long>;