using FluentValidation.Results;

namespace University.Application.Exceptions;

public class EntityValidationException : ApplicationException
{
    public EntityValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public EntityValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                         .ToDictionary(fg => fg.Key, fg => fg.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}