namespace TMS.Application;

public sealed class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {

        RuleFor(request => request.OldPassword).NotEmpty();
        RuleFor(request => request.NewPassword).NotEmpty();
        RuleFor(request => request.ConfirmPassword).NotEmpty();
    }
}
