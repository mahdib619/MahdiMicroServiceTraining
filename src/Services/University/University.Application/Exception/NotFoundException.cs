namespace University.Application.Exception;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"""Entity "{name}" with ({key}) was not found!""")
    {
    }
}
