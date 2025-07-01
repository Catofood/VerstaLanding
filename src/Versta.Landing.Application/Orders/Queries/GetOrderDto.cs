namespace Versta.Landing.Application.Orders.Queries;

public class GetOrderDto
{
    public long Id { get; set; }
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string ReceiverCity { get; set; }
    public string ReceiverAddress { get; set; }
    public decimal PackageWeightKg { get; set; }
    public DateTimeOffset PackagePickupDate { get; set; }
}
