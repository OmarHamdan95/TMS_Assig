namespace TMS.Application;

public sealed class GetTaskByStatusRequestValidator : AbstractValidator<GetTaskByStatusRequest>
{
    public GetTaskByStatusRequestValidator() => RuleFor(request => request.status).NotNull();
}
