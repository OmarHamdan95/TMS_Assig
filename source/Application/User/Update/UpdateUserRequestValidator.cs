namespace TMS.Application;

public sealed class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(request => request.Id).Id();
        RuleFor(request => request.NameEn).Name();
        RuleFor(request => request.NameAr).Name();
        RuleFor(request => request.MobileNumber).NotEmpty();
        RuleFor(request => request.Email).Email();
    }
}
