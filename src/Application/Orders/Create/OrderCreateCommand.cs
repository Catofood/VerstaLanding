namespace Application.Orders.Create;

public record OrderCreateCommand(
    long OrderId, 
    string SenderCity,
    string SenderAddress,
    string ReceiverCity,
    string ReceiverAddress,
    decimal PackageWeightKg,
    DateTimeOffset PackagePickupDate) : IRequest<Unit>;