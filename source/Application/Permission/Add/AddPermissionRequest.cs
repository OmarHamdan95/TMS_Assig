using AjKpi.Model;

namespace AjKpi.Application;

public  sealed record AddPermissionRequest(string Code,string? NameAr, string? NameEn ,int RoleId) : IRequest<Result<long>>;
