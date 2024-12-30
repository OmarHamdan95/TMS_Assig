namespace TMS.Application;

public sealed class UpdateTaskRequestValidator : AbstractValidator<UpdateTaskRequest>
{
    public UpdateTaskRequestValidator()
    {
        RuleFor(request => request.Id).Id();
        RuleFor(request => request.Title).Name();
        RuleFor(request => request.AssignedToId).NotNull();
        RuleFor(request => request.Status).NotEmpty();
        RuleFor(request => request.Priority).NotEmpty();
        RuleFor(request => request.DueDate).NotEmpty();
    }
}
