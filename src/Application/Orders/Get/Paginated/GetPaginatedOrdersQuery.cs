using Application.Common.Pagination;
using Application.Orders.Get.Single;

namespace Application.Orders.Get.Paginated;

public record GetPaginatedOrdersQuery(int Page = 1, int PageSize = 10) : IRequest<PaginatedList<GetOrderDto>>;