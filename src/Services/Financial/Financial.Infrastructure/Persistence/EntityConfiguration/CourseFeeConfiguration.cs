using Financial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Infrastructure.Persistence.EntityConfiguration;

internal class CourseFeeConfiguration : IEntityTypeConfiguration<CourseFee>
{
    public void Configure(EntityTypeBuilder<CourseFee> builder)
    {
        builder.HasKey(e => e.CourseCode);

        builder.Property(e => e.Id).UseIdentityColumn()
                                   .ValueGeneratedOnAddOrUpdate();

        builder.Property(e => e.Fee).HasPrecision(18, 0);
    }
}
