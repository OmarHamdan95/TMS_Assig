using TMS.Model;

namespace TMS.Application;

public  sealed record AddLookupValueRequest(string Code,string? NameAr, string? NameEn ,int LookupId, string? dataType ,  LookupModel? parent) : IRequest<Result<long>>;
