namespace GeneralHelpers.Exceptions;

public class NotFoundException : ClientException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string name, object key) : base($"""Entity "{name}" with ({key}) was not found!""")
    {
    }
}
