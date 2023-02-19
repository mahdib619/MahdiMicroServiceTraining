using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;

namespace University.Infrasturcture.Persistence;

internal static class UniDbSeeder
{
    public static async Task SeedAsync(UniDbContext context)
    {
        await SeedCourses(context);
        await SeedTerms(context);
        await SeedMajors(context);
        await SeedStudents(context);
        await SeedStudentCourses(context);

        await context.SaveChangesAsync();
    }

    private static async Task SeedCourses(UniDbContext context)
    {
        if (await context.Courses.AnyAsync())
            return;

        await context.Courses.AddRangeAsync(
            new Course { Code = "12345-1234", Name = "نصب و راه اندازی شبکه", TheoricalUnitsCount = 2, PracticalUnitsCount = 1 },
            new Course { Code = "12345-1235", Name = "مباحث ویژه", TheoricalUnitsCount = 2, PracticalUnitsCount = 1 },
            new Course { Code = "12345-1236", Name = "معادلات دیفرانسیل", TheoricalUnitsCount = 3, PracticalUnitsCount = 0 },
            new Course { Code = "12345-1237", Name = "آمار و احتمال", TheoricalUnitsCount = 2, PracticalUnitsCount = 0 },
            new Course { Code = "12345-1238", Name = "ریاضی گسسته", TheoricalUnitsCount = 2, PracticalUnitsCount = 0 }
        );
    }
    private static async Task SeedTerms(UniDbContext context)
    {
        if (await context.Terms.AnyAsync())
            return;

        context.Terms.AttachRange(
           new Term { Name = "4001", StartDate = new(2022, 5, 1), EndDate = new(2022, 12, 1) },
           new Term { Name = "4002", StartDate = new(2023, 1, 1), EndDate = new(2023, 4, 1) },
           new Term { Name = "4011", StartDate = new(2023, 5, 1), EndDate = new(2023, 12, 1) },
           new Term { Name = "4012", StartDate = new(2024, 1, 1), EndDate = new(2024, 4, 1) }
        );
    }
    private static async Task SeedMajors(UniDbContext context)
    {
        if (await context.Majors.AnyAsync())
            return;

        await context.Majors.AddRangeAsync(
            new Major { Name = "مهندسی نرم افزار", Code = "1234567" }
        );
    }
    private static async Task SeedStudents(UniDbContext context)
    {
        if (await context.Students.AnyAsync())
            return;

        var terms = context.ChangeTracker.Entries<Term>().Select(e => e.Entity).ToArray();
        var majors = context.ChangeTracker.Entries<Major>().Select(e => e.Entity).ToArray();

        await context.Students.AddRangeAsync(
            new Student { FirstName = "مهدی", LastName = "بغرائی", StudentNumber = "123456789101112", Major = majors[0], SignUpTerm = terms[0] },
            new Student { FirstName = "اکبر", LastName = "رضایی", StudentNumber = "123456789101113", Major = majors[0], SignUpTerm = terms[1] }
        );
    }
    private static async Task SeedStudentCourses(UniDbContext context)
    {
        if (await context.StudentCourses.AnyAsync())
            return;

        var students = context.ChangeTracker.Entries<Student>().Select(e => e.Entity).ToArray();
        var courses = context.ChangeTracker.Entries<Course>().Select(e => e.Entity).ToArray();
        var terms = context.ChangeTracker.Entries<Term>().Select(e => e.Entity).ToArray();

        await context.StudentCourses.AddRangeAsync(
            new StudentCourse { Student = students[0], Course = courses[0], Term = terms[0] },
            new StudentCourse { Student = students[0], Course = courses[2], Term = terms[0], IsDeleted = true },
            new StudentCourse { Student = students[0], Course = courses[2], Term = terms[0] },
            new StudentCourse { Student = students[0], Course = courses[1], Term = terms[0], IsPassed = true },
            new StudentCourse { Student = students[1], Course = courses[1], Term = terms[0], IsPassed = true },
            new StudentCourse { Student = students[1], Course = courses[1], Term = terms[0] },
            new StudentCourse { Student = students[0], Course = courses[0], Term = terms[1] },
            new StudentCourse { Student = students[0], Course = courses[2], Term = terms[1] }
        );
    }
}
