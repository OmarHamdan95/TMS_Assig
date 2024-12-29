namespace AjKpi.Application;

public sealed class UpdateLookupValueRequestValidator : AbstractValidator<UpdateLookupValueRequest>
{
    public UpdateLookupValueRequestValidator()
    {
        RuleFor(request => request.Id).Id();
       
    }
}
