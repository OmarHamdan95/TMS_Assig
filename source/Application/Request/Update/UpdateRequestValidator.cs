namespace AjKpi.Application;

public sealed class UpdateRequestValidator : AbstractValidator<UpdateRequest>
{
    public UpdateRequestValidator()
    {
        RuleFor(request => request.RequestId).NotEmpty();
    }
}
