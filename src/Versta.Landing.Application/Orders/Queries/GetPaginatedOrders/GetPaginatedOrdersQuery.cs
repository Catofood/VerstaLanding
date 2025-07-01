using Versta.Landing.Application.Common.Pagination;

namespace Versta.Landing.Application.Orders.Queries.GetPaginatedOrders;

public record GetPaginatedOrdersQuery(int Page = 1, int PageSize = 10) : IRequest<PaginatedList<GetOrderDto>>;