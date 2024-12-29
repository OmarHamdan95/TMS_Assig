namespace AjKpi.Application;

public sealed class UpdateTaskListResultKpiRequestValidator : AbstractValidator<UpdateTaskListResultKpiRequest>
{
    public UpdateTaskListResultKpiRequestValidator()
    {
        RuleFor(request => request.Items).NotEmpty();
    }
}
