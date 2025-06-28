namespace Domain.Entities;

public class Order
{
    public long Id { get; private set; }
    public string SenderCity { get; private set; }
    public string SenderAddress { get; private set; }
    public string ReceiverCity { get; private set; }
    public string ReceiverAddress { get; private set; }
    public decimal PackageWeightKg { get; private set; }
    public DateTimeOffset PackagePickupDate { get; private set; }
    
    // Для EF, не удалять
    private Order() { }

    public Order(
        long id,
        string senderCity,
        string senderAddress,
        string receiverCity,
        string receiverAddress,
        decimal packageWeightKg,
        DateTimeOffset packagePickupDate)
    {
        if (string.IsNullOrWhiteSpace(senderCity))
            throw new ArgumentException("Sender city is required.", nameof(SenderCity));
        if (senderCity.Length > 256)
            throw new ArgumentException("Sender city name is too long.", nameof(SenderCity));
        if (string.IsNullOrWhiteSpace(senderAddress))
            throw new ArgumentException("Sender address is required.", nameof(SenderAddress));
        if (senderAddress.Length > 1024)
            throw new ArgumentException("Sender address is too long.", nameof(SenderAddress));
        if (string.IsNullOrWhiteSpace(receiverCity))
            throw new ArgumentException("Receiver city is required.", nameof(ReceiverCity));
        if (receiverCity.Length > 256)
            throw new ArgumentException("Receiver city name is too long.", nameof(ReceiverCity));
        if (string.IsNullOrWhiteSpace(receiverAddress))
            throw new ArgumentException("Receiver address is required.", nameof(ReceiverAddress));
        if (receiverAddress.Length > 1024)
            throw new ArgumentException("Receiver address is too long.", nameof(ReceiverAddress));
        if (packageWeightKg <= 0)
            throw new ArgumentException("Package weight must be greater than zero.", nameof(packageWeightKg));
        Id = id;
        SenderCity = senderCity;
        SenderAddress = senderAddress;
        ReceiverCity = receiverCity;
        ReceiverAddress = receiverAddress;
        PackageWeightKg = packageWeightKg;
        PackagePickupDate = packagePickupDate;
    }

}