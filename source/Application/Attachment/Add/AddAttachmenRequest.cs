namespace AjKpi.Application;

public sealed record AddAttachmenRequest (List<AttachemntGroupModel> Attachments) : IRequest<Result<long>>;
