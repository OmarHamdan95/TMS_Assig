namespace AjKpi.Application;

public sealed class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
    {
        RuleFor(request => request.NameAr).Name();
        RuleFor(request => request.Email).Email();
        RuleFor(request => request.Login).Login();
        RuleFor(request => request.Password).Password();
    }
}
