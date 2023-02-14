using EventBus.Messages.Events;
using Financial.Application.Features.Debts.Commands.DeleteLastStudentDebt;
using MassTransit;
using MediatR;

namespace Financial.Api.EventBusConsumers;

public class StudentDeletedCourseConsumer : IConsumer<StudentDeletedCourseEvent>
{
    private readonly IMediator _mediator;

    public StudentDeletedCourseConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<StudentDeletedCourseEvent> context)
    {
        var message = context.Message;
        await _mediator.Send(new DeleteLastStudentDebtCommand(message.StudentNumber, message.DeletedCourseId.ToString()));
    }
}
