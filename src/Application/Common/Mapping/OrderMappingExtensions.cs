using Application.Orders.Commands.Create;
using Application.Orders.Query;
using Domain.Entities;

namespace Application.Common.Mapping;

public static class OrderMappingExtensions
{
    public static Order ToEntity(this CreateOrderDto createOrderDto)
    {
        var orderEntity = new Order(){
            SenderCity = createOrderDto.SenderCity,
            SenderAddress = createOrderDto.SenderAddress,
            ReceiverCity = createOrderDto.ReceiverCity,
            ReceiverAddress = createOrderDto.ReceiverAddress,
            PackageWeightKg = createOrderDto.PackageWeightKg,
            PackagePickupDate = createOrderDto.PackagePickupDate};
        return orderEntity;
    }

    public static GetOrderDto ToDto(this Order orderEntity)
    {
        var orderGetDto = new GetOrderDto(
            orderEntity.Id,
            orderEntity.SenderCity,
            orderEntity.SenderAddress,
            orderEntity.ReceiverCity,
            orderEntity.ReceiverAddress,
            orderEntity.PackageWeightKg,
            orderEntity.PackagePickupDate
        );
        return orderGetDto;
    }
}