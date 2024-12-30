namespace TMS.Application;

public sealed class GetTaskRequestValidator : AbstractValidator<GetTaskRequest>
{
    public GetTaskRequestValidator() => RuleFor(request => request.Id).Id();
}
