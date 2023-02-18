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

        await context.Terms.AddRangeAsync(
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

        await context.Students.AddRangeAsync(
            new Student { FirstName = "مهدی", LastName = "بغرائی", StudentNumber = "123456789101112", Major = await context.Majors.FirstAsync(), SignUpTerm = await context.Terms.FirstAsync() },
            new Student { FirstName = "اکبر", LastName = "رضایی", StudentNumber = "123456789101113", Major = await context.Majors.FirstAsync(), SignUpTerm = context.Terms.ElementAt(2) }
        );
    }
    private static async Task SeedStudentCourses(UniDbContext context)
    {
        if (await context.StudentCourses.AnyAsync())
            return;

        var students = await context.Students.ToArrayAsync();
        var courses = await context.Courses.ToArrayAsync();
        var terms = await context.Terms.Take(2).ToListAsync();

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
