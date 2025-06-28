namespace Application.Orders.Dtos;

public record OrderCreateDto(
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal PackageWeightKg,
    DateTimeOffset PackagePickupDate);