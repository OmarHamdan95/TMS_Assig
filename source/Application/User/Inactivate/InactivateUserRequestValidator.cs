namespace TMS.Application;

public sealed class InactivateUserRequestValidator : AbstractValidator<InactivateUserRequest>
{
    public InactivateUserRequestValidator() => RuleFor(request => request.Id).Id();
}
