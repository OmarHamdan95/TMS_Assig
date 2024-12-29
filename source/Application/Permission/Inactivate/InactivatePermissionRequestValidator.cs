namespace AjKpi.Application;

public sealed class InactivatePermissionRequestValidator : AbstractValidator<InactivatePermissionRequest>
{
    public InactivatePermissionRequestValidator() => RuleFor(request => request.Id).Id();
}
