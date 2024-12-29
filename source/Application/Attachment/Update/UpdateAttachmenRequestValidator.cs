namespace AjKpi.Application;

public sealed class UpdateAttachmenRequestValidator : AbstractValidator<UpdateAttachmenRequest>
{
    public UpdateAttachmenRequestValidator()
    {
        RuleFor(request => request.Id).Id();
    }
}
