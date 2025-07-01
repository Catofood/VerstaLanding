using AutoMapper;
using AutoMapper.QueryableExtensions;
using Versta.Landing.Application.Common.Pagination;
using Versta.Landing.Application.Interfaces;

namespace Versta.Landing.Application.Orders.Queries.GetPaginatedOrders;

public class GetPaginatedOrdersHandler : IRequestHandler<GetPaginatedOrdersQuery, PaginatedList<GetOrderDto>>
{
    private readonly IOrdersDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPaginatedOrdersHandler(IOrdersDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<GetOrderDto>> Handle(GetPaginatedOrdersQuery request, CancellationToken cancellationToken)
    {
        var page = request.Page;
        var pageSize = request.PageSize;
        var paginatedOrderDtos = await _dbContext.Orders
            .OrderBy(x => x.Id)
            .ProjectTo<GetOrderDto>(_mapper.ConfigurationProvider)
            .ToPaginatedListAsync(page, pageSize, cancellationToken);
        return paginatedOrderDtos;
    }
}