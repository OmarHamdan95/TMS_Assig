namespace AjKpi.Application;

public sealed class AddAttachmenRequestValidator :  AbstractValidator<AddAttachmenRequest>
{
    public AddAttachmenRequestValidator()
    {
        RuleFor(request => request.Attachments).NotEmpty();
        //RuleFor(request => request.TranslationModel).NotEmpty();
    }
}
