using AutoMapper;
using University.Application.Dtos.StudentCourse;
using University.Application.Features.StudentCourses.Commands.DeleteStudentCourse;
using University.Application.Features.StudentCourses.Commands.UpdateStudentCourse;

namespace University.Application.MapProfiles;

internal class StudentCourse : Profile
{
    public StudentCourse()
    {
        CreateMap<StudentCourse, GetStudentCourseDto>();
        CreateMap<UpdateStudentCourseCommand, StudentCourse>();
        CreateMap<DeleteStudentCourseCommand, StudentCourse>();
    }
}
