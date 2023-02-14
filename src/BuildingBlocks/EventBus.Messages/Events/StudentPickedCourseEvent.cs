namespace EventBus.Messages.Events;

public class StudentPickedCourseEvent : IntegrationBaseEvent
{
    public StudentPickedCourseEvent()
    {
    }

    public StudentPickedCourseEvent(Guid guid, DateTime creationDate) : base(guid, creationDate)
    {
    }

    public string StudentNumber { get; set; }
    public string MajorCode { get; set; }
    public int PickedCourseId { get; set; }
    public bool IsFirstPickedCoursInTerm { get; set; }
}
