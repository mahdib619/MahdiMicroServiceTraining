using System.Reflection;
using Financial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Financial.Infrastructure.Persistence;

internal class FinancialDbContext : DbContext
{
    public FinancialDbContext(DbContextOptions<FinancialDbContext> options) : base(options)
    {
    }

    public DbSet<CourseFee> CourseFees { get; set; }
    public DbSet<Debt> Debts { get; set; }
    public DbSet<MajorFee> MajorFees { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}