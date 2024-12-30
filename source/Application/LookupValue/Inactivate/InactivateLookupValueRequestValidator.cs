namespace TMS.Application;

public sealed class InactivateLookupValueRequestValidator : AbstractValidator<InactivateLookupValueRequest>
{
    public InactivateLookupValueRequestValidator() => RuleFor(request => request.Id).Id();
}
