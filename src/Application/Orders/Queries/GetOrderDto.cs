namespace Application.Orders.Query;

public record GetOrderDto(
    long OrderId,
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal PackageWeightKg,
    DateTimeOffset PackagePickupDate);