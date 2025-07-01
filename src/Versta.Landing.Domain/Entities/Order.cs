using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Versta.Landing.Domain.Entities;

public class Order
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    
    [Column("sender_city")]
    public string SenderCity { get; set; }
    
    [Column("sender_address")]
    public string SenderAddress { get; set; }
    
    [Column("receiver_city")]
    public string ReceiverCity { get; set; }
    
    [Column("receiver_address")]
    public string ReceiverAddress { get; set; }
    
    [Column("package_weight_kg")]
    public decimal PackageWeightKg { get; set; }
    [Column("package_pickup_date")]
    public DateTimeOffset PackagePickupDate { get; set; }
}