namespace Application.Orders.Dtos;

public record OrderGetDto(
    long OrderId,
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal PackageWeightKg,
    DateTimeOffset PackagePickupDate);