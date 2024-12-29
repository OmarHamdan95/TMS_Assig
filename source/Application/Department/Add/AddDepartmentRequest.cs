using AjKpi.Model;

namespace AjKpi.Application;

public  sealed record AddDepartmentRequest(string Code,string? NameAr, string? NameEn) : IRequest<Result<long>>;
