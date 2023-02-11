using FluentValidation.Results;
using GeneralHelpers.Exceptions;

namespace ValidationHelpers.Extensions;

public static class ValidationFailureExtensions
{
    public static void ThrowEntityValidationExceptionIfNotEmpty(this IEnumerable<ValidationFailure> failures)
    {
        if (failures is null)
            return;

        var failuresDict = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                                   .ToDictionary(fg => fg.Key, fg => fg.ToArray());

        if (failuresDict.Any())
            throw new EntityValidationException(failuresDict);
    }

    public static void ThrowEntityValidationException(this ValidationFailure failure)
    {
        if (failure is null)
            return;

        var failuresDict = new Dictionary<string, string[]> { [failure.PropertyName] = new[] { failure.ErrorMessage } };
        throw new EntityValidationException(failuresDict);
    }
}