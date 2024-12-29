namespace AjKpi.Application;

public sealed class UpdatePermissionRequestValidator : AbstractValidator<UpdatePermissionRequest>
{
    public UpdatePermissionRequestValidator()
    {
        RuleFor(request => request.Id).Id();
       
    }
}
