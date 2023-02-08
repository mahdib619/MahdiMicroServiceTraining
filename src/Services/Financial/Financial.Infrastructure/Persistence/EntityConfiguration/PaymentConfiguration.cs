using Financial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Infrastructure.Persistence.EntityConfiguration;

internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Property(e => e.StudentNumber)
               .IsRequired()
               .HasMaxLength(15)
               .HasColumnType("varchar");

        builder.Property(e => e.Amount).HasPrecision(18, 0);
    }
}
