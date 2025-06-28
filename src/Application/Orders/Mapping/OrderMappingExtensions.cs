using Application.Orders.Dtos;
using Domain.Entities;

namespace Application.Orders.Mapping;

public static class OrderMappingExtensions
{
    public static Order ToEntity(this OrderCreateDto orderCreateDto)
    {
        var orderEntity = new Order(
            orderCreateDto.SenderCity,
            orderCreateDto.SenderAddress,
            orderCreateDto.ReceiverCity,
            orderCreateDto.ReceiverAddress,
            orderCreateDto.PackageWeightKg,
            orderCreateDto.PackagePickupDate
        );
        return orderEntity;
    }

    public static OrderGetDto ToDto(this Order orderEntity)
    {
        var orderGetDto = new OrderGetDto(
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