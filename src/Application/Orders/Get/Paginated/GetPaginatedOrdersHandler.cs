using Application.Common.Pagination;
using Application.Interfaces;
using Application.Orders.Get.Single;
using Application.Orders.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Get.Paginated;

public class GetPaginatedOrdersHandler : IRequestHandler<GetPaginatedOrdersQuery, PaginatedList<GetOrderDto>>
{
    private readonly IOrdersDbContext _dbContext;

    public GetPaginatedOrdersHandler(IOrdersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginatedList<GetOrderDto>> Handle(GetPaginatedOrdersQuery request, CancellationToken cancellationToken)
    {
        var page = request.Page;
        var pageSize = request.PageSize;
        var paginatedOrderDtos = await _dbContext.Orders
            .OrderBy(x => x.Id)
            .Select(x => x.ToDto())
            .ToPaginatedListAsync(page, pageSize, cancellationToken);
        return paginatedOrderDtos;
    }
}