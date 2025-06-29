namespace Application.Orders.Get;

public record GetOrderDto(
    long OrderId,
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal PackageWeightKg,
    DateTimeOffset PackagePickupDate);