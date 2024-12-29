namespace AjKpi.Application;

public sealed class InactivateRoleRequestValidator : AbstractValidator<InactivateRoleRequest>
{
    public InactivateRoleRequestValidator() => RuleFor(request => request.Id).Id();
}
