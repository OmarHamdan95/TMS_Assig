using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GetAttachmenRequest(long Id) : IRequest<Result<AttachemntGroupModel>>;
