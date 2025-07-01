using Versta.Landing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Versta.Landing.Application.Interfaces;

public interface IOrdersDbContext
{
    public DbSet<Order> Orders { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}