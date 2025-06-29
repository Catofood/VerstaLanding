namespace Application.Orders.Get.Paginated;

public class GetPaginatedOrdersQueryValidator : AbstractValidator<GetPaginatedOrdersQuery>
{
    private const int MaxPageSize = 100;

    public GetPaginatedOrdersQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0);
        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, MaxPageSize);
    }
}