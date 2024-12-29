namespace AjKpi.Application;

public sealed class AddRoleRequestValidator : AbstractValidator<AddRoleRequest>
{
    public AddRoleRequestValidator()
    {
        RuleFor(request => request.Code).Name();
        RuleFor(request => request.NameAr).NotEmpty();
        RuleFor(request => request.NameEn).NotEmpty();
        RuleFor(request => request.DepartmentId).NotEmpty();
    }
}
