﻿using Financial.Application.Dtos.Debt;
using Financial.Domain.Entities;
using Financial.Domain.Enums;
using MediatR;

namespace Financial.Application.Features.Debts.Commands.CreateCourseDebt;

public class CreateCourseDebtCommand : IRequest<GetDebtDto>
{
    public string StudentNumber { get; set; }
    public int CourseId { get; set; }
    public DateTime DateTime { get; set; }
    public string Description { get; set; }

    public Debt ToDebtEntity() => new()
    {
        StudentNumber = StudentNumber,
        SourceId = CourseId.ToString(),
        DebtSourseType = DebtSourseType.CourseFee,
        DateTime = DateTime,
        Description = Description
    };
}
