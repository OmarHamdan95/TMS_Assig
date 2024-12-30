namespace TMS.Application;

public sealed class AddLookupValueRequestValidator :  AbstractValidator<AddLookupValueRequest>
{
    public AddLookupValueRequestValidator()
    {
        RuleFor(request => request.Code).Name();
        RuleFor(request => request.NameAr).NotEmpty();
        RuleFor(request => request.NameEn).NotEmpty();
        RuleFor(request => request.LookupId).NotEmpty();
    }
}
