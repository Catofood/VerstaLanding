namespace Versta.Landing.Application.Orders.Queries.GetOrder;

public record GetOrderQuery(long OrderId) : IRequest<GetOrderDto>;