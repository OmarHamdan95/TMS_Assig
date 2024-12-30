namespace TMS.Application;

public sealed record AddUserRequest(string NameAr , string NameEn , string MobileNumber, string Email, string Login,
    string Password , UserRole? Role) : IRequest<Result<long>>;
