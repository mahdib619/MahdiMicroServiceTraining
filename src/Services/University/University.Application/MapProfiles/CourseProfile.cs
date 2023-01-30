using AutoMapper;
using University.Application.Dtos.Course;
using University.Application.Features.Courses.Commands.CreateCourse;
using University.Application.Features.Courses.Commands.UpdateCourse;
using University.Domain.Entities;

namespace University.Application.MapProfiles;

internal class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, GetCourseDto>();
        CreateMap<CreateCourseCommand, Course>();
        CreateMap<UpdateCourseCommand, Course>();
    }
}
