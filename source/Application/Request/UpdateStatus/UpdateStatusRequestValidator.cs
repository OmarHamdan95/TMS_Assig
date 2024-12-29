namespace AjKpi.Application;

public sealed class UpdateStatusRequestValidator : AbstractValidator<UpdateRequestStatus>
{
    public UpdateStatusRequestValidator()
    {
        RuleFor(request => request.RequestId).NotEmpty();
    }
}
