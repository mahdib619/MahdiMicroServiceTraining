using AutoMapper;
using University.Application.Dtos.Term;
using University.Application.Features.Terms.Commands.CreateTerm;
using University.Application.Features.Terms.Commands.UpdateTerm;
using University.Domain.Entities;

namespace University.Application.MapProfiles;

internal class TermProfile : Profile
{
    public TermProfile()
    {
        CreateMap<Term, GetTermDto>();
        CreateMap<CreateTermCommand, Term>();
        CreateMap<UpdateTermCommand, Term>();
    }
}
