using Application.Common.Pagination;
using Application.Orders.Query;

namespace Application.Orders.Queries.GetPaginatedOrders;

public record GetPaginatedOrdersQuery(int Page = 1, int PageSize = 10) : IRequest<PaginatedList<GetOrderDto>>;