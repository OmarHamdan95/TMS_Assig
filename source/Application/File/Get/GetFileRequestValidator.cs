namespace AjKpi.Application;

public sealed class GetFileRequestValidator : AbstractValidator<GetFileRequest>
{
    public GetFileRequestValidator() => RuleFor(request => request.Id).Guid();
}
