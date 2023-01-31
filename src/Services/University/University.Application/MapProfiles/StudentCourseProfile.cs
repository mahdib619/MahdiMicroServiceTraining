using AutoMapper;
using University.Application.Dtos.StudentCourse;
using University.Application.Features.StudentCourses.Commands.CreateStudentCourse;
using University.Application.Features.StudentCourses.Commands.UpdateStudentCourse;
using University.Domain.Entities;

namespace University.Application.MapProfiles;

internal class StudentCourseProfile : Profile
{
    public StudentCourseProfile()
    {
        CreateMap<StudentCourse, GetStudentCourseDto>();
        CreateMap<UpdateStudentCourseCommand, StudentCourse>();
        CreateMap<CreateStudentCourseCommand, StudentCourse>();
    }
}
