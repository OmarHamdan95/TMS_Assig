namespace AjKpi.Application;

public sealed class DeletePermissionRequestValidator : AbstractValidator<DeletePermissionRequest>
{
    public DeletePermissionRequestValidator() => RuleFor(request => request.Id).Id();
}
