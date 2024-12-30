namespace TMS.Application;

public sealed class AddTaskRequestValidator : AbstractValidator<AddTaskRequest>
{
    public AddTaskRequestValidator()
    {
        RuleFor(request => request.Title).Name();
        RuleFor(request => request.Status).NotEmpty();
        RuleFor(request => request.Priority).NotEmpty();
        RuleFor(request => request.DueDate).NotEmpty();
        RuleFor(request => request.AssignedToId).NotEmpty();
    }
}
