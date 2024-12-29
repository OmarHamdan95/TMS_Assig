namespace AjKpi.Application;

public sealed class AddPermissionRequestValidator :  AbstractValidator<AddPermissionRequest>
{
    public AddPermissionRequestValidator()
    {
        RuleFor(request => request.Code).Name();
        RuleFor(request => request.NameAr).NotEmpty();
        RuleFor(request => request.NameEn).NotEmpty();
        RuleFor(request => request.RoleId).NotEmpty();
    }
}
