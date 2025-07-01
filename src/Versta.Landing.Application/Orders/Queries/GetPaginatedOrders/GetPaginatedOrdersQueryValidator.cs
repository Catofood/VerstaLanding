using Microsoft.Extensions.Options;
using Versta.Landing.Application.Settings;

namespace Versta.Landing.Application.Orders.Queries.GetPaginatedOrders;

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