using AutoMapper;
using Financial.Application.Dtos.Debt;
using Financial.Application.Features.Debts.Commands.CreateCourseDebt;
using Financial.Application.Features.Debts.Commands.CreateMajorDebt;
using Financial.Domain.Entities;

namespace Financial.Application.MapProfiles;

internal class DebtProfile : Profile
{
    public DebtProfile()
    {
        CreateMap<Debt, GetDebtDto>();
        CreateMap<CreateCourseDebtCommand, Debt>().ConstructUsing(e => e.ToDebtEntity());
        CreateMap<CreateMajorDebtCommand, Debt>().ConstructUsing(e => e.ToDebtEntity());
    }
}
