namespace AjKpi.Application;

public sealed record CountWfStageByStepDashboardRequest(string? stepCode) : IRequest<Result<long>>;
