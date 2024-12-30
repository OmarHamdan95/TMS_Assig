using TMS.Model;

namespace TMS.Application;

public  sealed record AddLookupRequest (string Code,string? NameAr, string? NameEn ,
    List<LookupValueModel>? LookupValueModels , string? dataType ,  LookupModel? parent) : IRequest<Result<long>>;
