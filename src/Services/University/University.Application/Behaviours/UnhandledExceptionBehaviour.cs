using MediatR;
using Microsoft.Extensions.Logging;
using University.Application.Exceptions;

namespace University.Application.Behaviours;

internal class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly HashSet<string> _clientExceptionsTypeNames = new() { typeof(EntityValidationException).FullName, typeof(NotFoundException).FullName };
    private readonly ILogger<UnhandledExceptionBehaviour<TRequest, TResponse>> _logger;

    public UnhandledExceptionBehaviour(ILogger<UnhandledExceptionBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex) when (!IsClientError(ex))
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ex, "Application Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
            throw;
        }
    }

    private bool IsClientError(Exception ex) => _clientExceptionsTypeNames.Contains(ex.GetType().FullName);
}
