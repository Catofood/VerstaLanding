using Application.Settings;
using Microsoft.Extensions.Options;

namespace Application.Orders.Queries.GetPaginatedOrders;

public class GetPaginatedOrdersQueryValidator : AbstractValidator<GetPaginatedOrdersQuery>
{
    public GetPaginatedOrdersQueryValidator(IOptions<InputLimitSettings> options)
    {
        var inputLimitSettings = options.Value;
        RuleFor(x => x.Page)
            .GreaterThan(0);
        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, inputLimitSettings.MaxOrdersPaginationPageSize);
    }
}