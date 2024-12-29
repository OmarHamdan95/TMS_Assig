using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ListAttachmenRequest : IRequest<Result<IEnumerable<AttachemntGroupModel>>>;
