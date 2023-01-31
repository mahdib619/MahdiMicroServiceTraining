using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace University.Infrasturcture.Persistence.EntityConfiguration;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasAlternateKey(s => s.StudentNumber);

        builder.Property(s => s.StudentNumber)
               .IsRequired()
               .HasMaxLength(15)
               .HasColumnType("varchar");

        builder.Property(s => s.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.LastName)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasOne(s => s.SignUpTerm)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction);
    }
}
