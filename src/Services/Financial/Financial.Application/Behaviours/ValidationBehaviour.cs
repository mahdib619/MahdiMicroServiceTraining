using Financial.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Financial.Application.Behaviours;

internal class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validaitonResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validaitonResults.SelectMany(vr => vr.Errors).Where(f => f is not null).ToList();

            if (failures.Any())
                throw new EntityValidationException(failures);
        }

        return await next();
    }
}
