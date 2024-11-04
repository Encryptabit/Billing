using Microsoft.EntityFrameworkCore;
using Billing.Domain.Entities;
using Billing.Domain.Entities.Dto;

namespace Billing.Infrastructure.Persistence;

internal class AppDbContext(
    DbContextOptions<AppDbContext> options) : DbContext(options)
{
       public DbSet<OrganizationDto> Organizations { get; init; }

       public DbSet<DatabaseDto> Databases { get; init; }
       public DbSet<EndUserDto> EndUsers { get; init; }
       public DbSet<DistributorDto> Distributors { get; init; }
       public DbSet<DistributorEndUserDto> DistributorEndUsers { get; init; }
       public DbSet<EndUserDatabaseDto> EndUserDatabase { get; init; }
       public DbSet<BillingDto> BillingHistory { get; init; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Ignore<Bill>();
           modelBuilder.Ignore<Domain.Entities.Billing>();

           modelBuilder.Entity<BillingDto>().ToTable("BillingHistory", "dbo");
           modelBuilder.Entity<OrganizationDto>().ToTable("Organizations","dbo");
           modelBuilder.Entity<DatabaseDto>().ToTable("Databases","dbo");
           modelBuilder.Entity<EndUserDto>().ToTable("EndUsers","dbo");
           modelBuilder.Entity<DistributorDto>().ToTable("Distributors","dbo");
           modelBuilder.Entity<DistributorEndUserDto>().ToTable("DistributorEndUsers","dbo");
           modelBuilder.Entity<EndUserDatabaseDto>().ToTable("EndUserDatabase","dbo");
       }
}
