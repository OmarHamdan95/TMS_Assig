using AjKpi.Model;

namespace AjKpi.Application;

public  sealed record AddLookupValueRequest(string Code,string? NameAr, string? NameEn ,int LookupId, string? dataType ,  LookupModel? parent) : IRequest<Result<long>>;
