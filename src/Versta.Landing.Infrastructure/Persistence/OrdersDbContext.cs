using Versta.Landing.Application.Interfaces;
using Versta.Landing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Versta.Landing.Infrastructure.Persistence;

public class OrdersDbContext : DbContext, IOrdersDbContext
{
    public DbSet<Order> Orders { get; set; }
    
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);
    }
}