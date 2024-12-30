namespace TMS.Application;

public sealed class AutoCompleteLookupRequestValidator : AbstractValidator<AutoCompleteLookupRequest>
{
    public AutoCompleteLookupRequestValidator() => RuleFor(request => request.lookupCode).NotEmpty();
}
