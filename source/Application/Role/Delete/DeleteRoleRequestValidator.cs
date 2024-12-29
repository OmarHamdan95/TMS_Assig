namespace AjKpi.Application;

public sealed class DeleteRoleRequestValidator : AbstractValidator<DeleteRoleRequest>
{
    public DeleteRoleRequestValidator() => RuleFor(request => request.Id).Id();
}
