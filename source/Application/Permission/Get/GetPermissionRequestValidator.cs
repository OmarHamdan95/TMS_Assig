namespace AjKpi.Application;

public sealed class GetPermissionRequestValidator : AbstractValidator<GetPermissionRequest>
{
    public GetPermissionRequestValidator() => RuleFor(request => request.Id).Id();
}
