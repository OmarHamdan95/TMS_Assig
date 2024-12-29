namespace AjKpi.Application;

public sealed class UpdateLookupRequestValidator : AbstractValidator<UpdateLookupRequest>
{
    public UpdateLookupRequestValidator()
    {
        RuleFor(request => request.Id).Id();
        RuleFor(request => request.LookupValueModels).NotEmpty();
    }
}
