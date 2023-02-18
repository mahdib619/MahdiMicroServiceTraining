using Financial.Domain.Entities;
using Financial.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Financial.Infrastructure.Persistence;

internal static class FinancialDbSeeder
{
    public static async Task SeedAsync(FinancialDbContext dbContext)
    {
        await SeedPayments(dbContext);
        await SeedDebts(dbContext);
        await SeedMajorFees(dbContext);
        await SeedCourseFees(dbContext);

        await dbContext.SaveChangesAsync();
    }

    private static async Task SeedPayments(FinancialDbContext dbContext)
    {
        if (await dbContext.Payments.AnyAsync())
            return;

        await dbContext.Payments.AddRangeAsync(
            new Payment { StudentNumber = "123456789101112", Amount = 20000000, PaymentTime = new(2022, 5, 1) },
            new Payment { StudentNumber = "123456789101112", Amount = 20000000, PaymentTime = new(2022, 5, 1) },
            new Payment { StudentNumber = "123456789101113", Amount = 20000000, PaymentTime = new(2023, 1, 1) },
            new Payment { StudentNumber = "123456789101112", Amount = 5000000, PaymentTime = new(2022, 5, 1) },
            new Payment { StudentNumber = "123456789101112", Amount = 14000000, PaymentTime = new(2022, 5, 1) },
            new Payment { StudentNumber = "123456789101113", Amount = 14000000, PaymentTime = new(2022, 5, 1) }
        );
    }

    private static async Task SeedDebts(FinancialDbContext dbContext)
    {
        if (await dbContext.Debts.AnyAsync())
            return;

        await dbContext.Debts.AddRangeAsync(
            new Debt { StudentNumber = "123456789101112", Amount = 20000000, DebtSourseType = DebtSourseType.MajorTermFee, SourceId = "1234567", DateTime = new(2022, 5, 1) },
            new Debt { StudentNumber = "123456789101112", Amount = 20000000, DebtSourseType = DebtSourseType.MajorTermFee, SourceId = "1234567", DateTime = new(2022, 5, 1) },
            new Debt { StudentNumber = "123456789101113", Amount = 20000000, DebtSourseType = DebtSourseType.MajorTermFee, SourceId = "1234567", DateTime = new(2023, 1, 1) },
            new Debt { StudentNumber = "123456789101112", Amount = 5000000, DebtSourseType = DebtSourseType.CourseFee, SourceId = "12345-1234", DateTime = new(2022, 5, 1) },
            new Debt { StudentNumber = "123456789101112", Amount = 3500000, DebtSourseType = DebtSourseType.CourseFee, SourceId = "12345-1236", DateTime = new(2022, 5, 1) },
            new Debt { StudentNumber = "123456789101112", Amount = 3500000, DebtSourseType = DebtSourseType.CourseFee, SourceId = "12345-1236", DateTime = new(2022, 5, 1) },
            new Debt { StudentNumber = "123456789101112", Amount = 7000000, DebtSourseType = DebtSourseType.CourseFee, SourceId = "12345-1235", DateTime = new(2022, 5, 1) },
            new Debt { StudentNumber = "123456789101113", Amount = 7000000, DebtSourseType = DebtSourseType.CourseFee, SourceId = "12345-1235", DateTime = new(2022, 5, 1) },
            new Debt { StudentNumber = "123456789101113", Amount = 7000000, DebtSourseType = DebtSourseType.CourseFee, SourceId = "12345-1235", DateTime = new(2022, 5, 1) },
            new Debt { StudentNumber = "123456789101112", Amount = 5000000, DebtSourseType = DebtSourseType.CourseFee, SourceId = "12345-1234", DateTime = new(2023, 1, 1) },
            new Debt { StudentNumber = "123456789101112", Amount = 3500000, DebtSourseType = DebtSourseType.CourseFee, SourceId = "12345-1236", DateTime = new(2023, 1, 1) }
        );
    }

    private static async Task SeedMajorFees(FinancialDbContext dbContext)
    {
        if (await dbContext.MajorFees.AnyAsync())
            return;

        await dbContext.MajorFees.AddRangeAsync(
            new MajorFee { MajorCode = "1234567", Fee = 20000000 }
        );
    }

    private static async Task SeedCourseFees(FinancialDbContext dbContext)
    {
        if (await dbContext.CourseFees.AnyAsync())
            return;

        await dbContext.CourseFees.AddRangeAsync(
            new CourseFee { CourseCode = "12345-1234", Fee = 5000000 },
            new CourseFee { CourseCode = "12345-1235", Fee = 7000000 },
            new CourseFee { CourseCode = "12345-1236", Fee = 3500000 },
            new CourseFee { CourseCode = "12345-1237", Fee = 3000000 },
            new CourseFee { CourseCode = "12345-1238", Fee = 3000000 }
        );
    }
}
