using System.Reflection;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;

namespace University.Infrasturcture.Persistence;

internal class UniDbContext : DbContext
{
    public UniDbContext(DbContextOptions<UniDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Term> Terms { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}