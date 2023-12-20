using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Reflection;

namespace Restman.Application.Common.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
        _validators = validators;
    }
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var errors = _validators
                        .Select(validator => validator.Validate(request))
                        .SelectMany(validationResult => validationResult.Errors)
                        .Where(validationFailure => validationFailure is not null)
                        .Distinct()
                        .ToList();

        if (errors.Any())
        {
            return TryCreateResponseFromErrors(errors, out var response)
                ? response
                : throw new ValidationException(errors);
        }

        return await next();
    }

    private static bool TryCreateResponseFromErrors(List<ValidationFailure> validationFailures, out TResponse response)
    {
        List<Error> errors = validationFailures.ConvertAll(x => Error.Validation(
                code: x.PropertyName,
                description: x.ErrorMessage));

        response = (TResponse?)typeof(TResponse)
            .GetMethod(
                name: nameof(ErrorOr<object>.From),
                bindingAttr: BindingFlags.Static | BindingFlags.Public,
                types: new[] { typeof(List<Error>) })?
            .Invoke(null, new[] { errors })!;

        return response is not null;
    }
}
