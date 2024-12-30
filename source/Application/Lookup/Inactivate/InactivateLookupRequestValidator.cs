namespace TMS.Application;

public sealed class InactivateLookupRequestValidator : AbstractValidator<InactivateLookupRequest>
{
    public InactivateLookupRequestValidator() => RuleFor(request => request.Id).Id();
}
