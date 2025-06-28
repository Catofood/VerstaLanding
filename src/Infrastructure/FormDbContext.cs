using Application.Interfaces;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class FormDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Order> Orders { get; set; }
}