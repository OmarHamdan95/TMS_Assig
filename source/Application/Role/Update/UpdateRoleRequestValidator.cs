namespace AjKpi.Application;

public sealed class UpdateRoleRequestValidator : AbstractValidator<UpdateRoleRequest>
{
    public UpdateRoleRequestValidator()
    {
        RuleFor(request => request.Id).Id();
        RuleFor(request => request.NameEn).Name();
        RuleFor(request => request.NameAr).Name();
    }
}
