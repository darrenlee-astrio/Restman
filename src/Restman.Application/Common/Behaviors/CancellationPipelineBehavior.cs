using ErrorOr;
using MediatR;

namespace Restman.Application.Common.Behaviors;

public class CancellationPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (OperationCanceledException)
        {
            throw;
        }
    }
}
