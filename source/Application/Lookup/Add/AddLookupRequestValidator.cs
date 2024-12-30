namespace TMS.Application;

public sealed class AddLookupRequestValidator :  AbstractValidator<AddLookupRequest>
{
    public AddLookupRequestValidator()
    {
        RuleFor(request => request.Code).Name();
        RuleFor(request => request.NameAr).NotEmpty();
        RuleFor(request => request.NameEn).NotEmpty();
    }
}
