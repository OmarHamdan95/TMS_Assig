namespace AjKpi.Application;

public sealed class AutoCompleteLookupRequestValidator : AbstractValidator<AutoCompleteLookupRequest>
{
    public AutoCompleteLookupRequestValidator() => RuleFor(request => request.lookupCode).NotEmpty();
}
