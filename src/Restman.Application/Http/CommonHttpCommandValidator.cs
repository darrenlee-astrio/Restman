using FluentValidation;
using Restman.Application.Common.Helpers;

namespace Restman.Application.Http;

public class CommonHttpCommandValidator : AbstractValidator<CommonHttpCommand>
{
    public CommonHttpCommandValidator()
    {
        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Url cannot be empty.")
            .Must(BeValidUrl).WithMessage("Invalid url.");

        RuleFor(x => x.Method)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Method cannot be empty.")
            .Must(BeParsableToHttpMethod).WithMessage("Invalid Method.");
    }

    private bool BeValidUrl(string urlString)
    {
        return UrlHelper.IsValid(urlString);
    }

    private bool BeParsableToHttpMethod(string methodString)
    {
        return HttpMethodHelper.TryParse(methodString, out var method);
    }
}