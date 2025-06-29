using Application.Orders.Create;
using Application.Orders.Get;
using Application.Orders.Get.Single;
using Domain.Entities;

namespace Application.Orders.Mapping;

public static class OrderMappingExtensions
{
    public static Order ToEntity(this CreateOrderDto createOrderDto)
    {
        var orderEntity = new Order(
            createOrderDto.SenderCity,
            createOrderDto.SenderAddress,
            createOrderDto.ReceiverCity,
            createOrderDto.ReceiverAddress,
            createOrderDto.PackageWeightKg,
            createOrderDto.PackagePickupDate
        );
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