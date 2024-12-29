using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridAttachmenRequest : GridParameters , IRequest<Result<Grid<AttachemntGroupModel>>>;
