namespace TMS.Application;

public sealed class SearchTaskRequestValidator : AbstractValidator<SearchTaskRequest>
{
    public SearchTaskRequestValidator()
    {
        RuleFor(request => request.pageIndex).NotNull();
        RuleFor(request => request.pageSize).NotNull();
    }
}
