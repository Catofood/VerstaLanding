using Application.Common.Pagination;
using Application.Orders.Commands.Create;
using Application.Orders.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping;

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