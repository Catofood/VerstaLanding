using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Order> Orders { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}