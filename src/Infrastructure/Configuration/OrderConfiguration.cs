using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.SenderCity)
            .IsRequired();

        builder.Property(x => x.SenderAddress)
            .IsRequired();


        builder.Property(x => x.ReceiverCity)
            .IsRequired();

        builder.Property(x => x.ReceiverAddress)
            .IsRequired();

        builder.Property(x => x.PackageWeightKg)
            .IsRequired();

        builder.Property(x => x.PackagePickupDate)
            .IsRequired();
        
    }
}