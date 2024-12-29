namespace AjKpi.Application;

public sealed class GetRoleRequestValidator : AbstractValidator<GetRoleRequest>
{
    public GetRoleRequestValidator() => RuleFor(request => request.Id).Id();
}
