namespace AjKpi.Application;

public sealed class AddRequestValidator :  AbstractValidator<AddAttachmenRequest>
{
    public AddRequestValidator()
    {
       // RuleFor(request => request.Attachments).NotEmpty();
        //RuleFor(request => request.TranslationModel).NotEmpty();
    }
}
