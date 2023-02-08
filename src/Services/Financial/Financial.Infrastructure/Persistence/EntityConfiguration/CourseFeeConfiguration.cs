using Financial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Infrastructure.Persistence.EntityConfiguration;

internal class CourseFeeConfiguration : IEntityTypeConfiguration<CourseFee>
{
    public void Configure(EntityTypeBuilder<CourseFee> builder)
    {
        builder.HasKey(e => e.CourseId);

        builder.Property(e => e.CourseId).ValueGeneratedNever();
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.Property(e => e.Fee).HasPrecision(18, 0);
    }
}
