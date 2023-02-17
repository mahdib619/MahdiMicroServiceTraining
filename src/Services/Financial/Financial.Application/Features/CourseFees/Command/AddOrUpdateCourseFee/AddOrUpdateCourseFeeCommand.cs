using Financial.Application.Dtos.CourseFee;
using MediatR;

namespace Financial.Application.Features.CourseFees.Command.AddOrUpdateCourseFee;

public class AddOrUpdateCourseFeeCommand : IRequest<GetCourseFeeDto>
{
    public string CourseCode { get; set; }
    public decimal Fee { get; set; }
}
