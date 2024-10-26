using Microsoft.EntityFrameworkCore;
using Billing.Domain.Entities;

namespace Billing.Infrastructure.Persistence;

public class AppDbContext(
    DbContextOptions<AppDbContext> options) : DbContext(options)
{
       public DbSet<Organization> Organizations { get; init; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Organization>().ToTable("Organizations","dbo");
       }
}