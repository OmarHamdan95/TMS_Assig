namespace AjKpi.Application;

public sealed record SubmitKpiReqeust(long? KpiId) : IRequest<Result>;

