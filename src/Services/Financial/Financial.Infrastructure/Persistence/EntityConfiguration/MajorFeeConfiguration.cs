using Financial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Infrastructure.Persistence.EntityConfiguration;

internal class MajorFeeConfiguration : IEntityTypeConfiguration<MajorFee>
{
    public void Configure(EntityTypeBuilder<MajorFee> builder)
    {
        builder.HasKey(e => e.MajorCode);

        builder.Property(e => e.Id).UseIdentityColumn()
                                   .ValueGeneratedOnAddOrUpdate();

        builder.Property(e => e.Fee).HasPrecision(18, 0);
    }
}
