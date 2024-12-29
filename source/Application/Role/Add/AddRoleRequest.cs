namespace AjKpi.Application;

public sealed record AddRoleRequest(string NameAr , string NameEn , string Code ,  long? DepartmentId) : IRequest<Result<long>>;
