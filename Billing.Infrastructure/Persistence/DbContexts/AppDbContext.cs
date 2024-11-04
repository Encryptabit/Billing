using Microsoft.EntityFrameworkCore;
using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;

namespace Billing.Infrastructure.Persistence;

internal class AppDbContext(
    DbContextOptions<AppDbContext> options) : DbContext(options)
{
       public DbSet<Organization> Organizations { get; init; }

       public DbSet<DatabaseDto> Databases { get; init; }
       public DbSet<EndUserDto> EndUsers { get; init; }
       public DbSet<DistributorDto> Distributors { get; init; }
       public DbSet<DistributorEndUserDto> DistributorEndUsers { get; init; }
       public DbSet<EndUserDatabaseDto> EndUsersDatabase { get; init; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Organization>().ToTable("Organizations","dbo");
       }
}
