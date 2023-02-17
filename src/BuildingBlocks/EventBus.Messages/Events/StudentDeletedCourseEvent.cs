namespace EventBus.Messages.Events;

public class StudentDeletedCourseEvent : IntegrationBaseEvent
{
    public StudentDeletedCourseEvent()
    {
    }

    public StudentDeletedCourseEvent(Guid id, DateTime creationDate) : base(id, creationDate)
    {
    }

    public string StudentNumber { get; set; }
    public string MajorCode { get; set; }
    public string DeletedCourseCode { get; set; }
}
