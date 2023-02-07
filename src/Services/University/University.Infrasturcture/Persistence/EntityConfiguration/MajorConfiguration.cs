using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace University.Infrasturcture.Persistence.EntityConfiguration;

internal class MajorConfiguration : IEntityTypeConfiguration<Major>
{
    public void Configure(EntityTypeBuilder<Major> builder)
    {
        builder.HasAlternateKey(m => m.Code);

        builder.Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(m => m.Code)
               .IsRequired()
               .HasMaxLength(7);
    }
}
