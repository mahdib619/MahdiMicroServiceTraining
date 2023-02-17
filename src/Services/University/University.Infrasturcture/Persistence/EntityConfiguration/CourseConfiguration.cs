using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace University.Infrasturcture.Persistence.EntityConfiguration;

internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasAlternateKey(m => m.Code);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(m => m.Code)
               .IsRequired()
               .HasMaxLength(10);
    }
}
