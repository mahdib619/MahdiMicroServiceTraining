using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.Domain.Entities;

namespace University.Infrasturcture.Persistence.EntityConfiguration;

internal class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.HasOne(sc => sc.Student)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(sc => sc.Course)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(sc => sc.Term)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction);
    }
}
