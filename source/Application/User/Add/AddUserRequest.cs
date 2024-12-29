namespace AjKpi.Application;

public sealed record AddUserRequest(string NameAr , string NameEn , string MobileNumber, string Email, string Login,
    string Password ,  long? DepartmentId , long? RoleId) : IRequest<Result<long>>;
