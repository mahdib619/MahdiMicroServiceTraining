namespace GeneralHelpers.Exceptions;

public class EntityValidationException : ClientException
{
    public EntityValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public EntityValidationException(IDictionary<string, string[]> errors) : this()
    {
        Errors = errors;
    }

    public IDictionary<string, string[]> Errors { get; }
}