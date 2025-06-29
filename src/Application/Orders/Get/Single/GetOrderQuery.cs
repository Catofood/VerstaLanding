namespace Application.Orders.Get.Single;

public record GetOrderQuery(long OrderId) : IRequest<GetOrderDto>;