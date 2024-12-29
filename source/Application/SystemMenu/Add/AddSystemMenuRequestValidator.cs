namespace AjKpi.Application;

public sealed class AddSystemMenuRequestValidator :  AbstractValidator<AddSystemMenuRequest>
{
    public AddSystemMenuRequestValidator()
    {
        RuleFor(request => request.Name).NotEmpty();
    }
}
