using EventBus.Messages.Events;
using Financial.Application.Features.Debts.Commands.CreateCourseDebt;
using Financial.Application.Features.Debts.Commands.CreateMajorDebt;
using MassTransit;
using MediatR;

namespace Financial.Api.EventBusConsumers;

public class StudentPickedCourseConsumer : IConsumer<StudentPickedCourseEvent>
{
    private readonly IMediator _mediator;

    public StudentPickedCourseConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<StudentPickedCourseEvent> context)
    {
        var message = context.Message;

        await _mediator.Send(new CreateCourseDebtCommand
        {
            StudentNumber = message.StudentNumber,
            CourseId = message.PickedCourseId,
            DateTime = message.CreationDate,
            Description = null
        });

        if (message.IsFirstPickedCoursInTerm)
        {
            await _mediator.Send(new CreateMajorDebtCommand
            {
                StudentNumber = message.StudentNumber,
                MajorCode = message.MajorCode,
                DateTime = message.CreationDate,
                Description = null
            });
        }
    }
}
