using AutoMapper;
using University.Application.Dtos.Student;
using University.Application.Features.Students.Commands.CreateStudent;
using University.Application.Features.Students.Commands.UpdateStudent;
using University.Domain.Entities;

namespace University.Application.MapProfiles;

internal class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, GetStudentDto>();
        CreateMap<UpdateStudentCommand, Student>();
        CreateMap<CreateStudentCommand, Student>();
    }
}
