using AutoMapper;
using Versta.Landing.Application.Common.Pagination;
using Versta.Landing.Application.Orders.Commands.Create;
using Versta.Landing.Application.Orders.Queries;
using Versta.Landing.Domain.Entities;

namespace Versta.Landing.Application.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateOrderDto, Order>()
            .ForMember(x => x.Id, opt => opt.Ignore());
        CreateMap<Order, GetOrderDto>();
        CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>));
    }
}