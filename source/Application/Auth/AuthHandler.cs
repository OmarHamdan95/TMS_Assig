using System.IdentityModel.Tokens.Jwt;
using AjKpi.Database;
using Newtonsoft.Json;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record AuthHandler : IRequestHandler<AuthRequest, Result<AuthResponse>>
{
    private readonly IAuthRepository _authRepository;
    private readonly IHashService _hashService;
    private readonly IJwtService _jwtService;
    private readonly IStringLocalizer _stringLocalizer;
    private readonly IRoleRepository _roleRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public AuthHandler
    (
        IAuthRepository authRepository,
        IHashService hashService,
        IJwtService jwtService,
        IStringLocalizer stringLocalizer,
        IRoleRepository roleRepository,
        IDepartmentRepository departmentRepository
    )
    {
        _authRepository = authRepository;
        _hashService = hashService;
        _jwtService = jwtService;
        _stringLocalizer = stringLocalizer;
        _roleRepository = roleRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<Result<AuthResponse>> Handle(AuthRequest request, CancellationToken cancellationToken)
    {
        var unauthorizedResult = new Result<AuthResponse>(Unauthorized, _stringLocalizer[nameof(Unauthorized)]);

        var auth = await _authRepository.GetByLoginAsync(request.Login);

        if (auth is null) return unauthorizedResult;

        if (!_hashService.Validate(auth.Password, request.Password, auth.Salt.ToString())) return unauthorizedResult;

        if(auth.User.RoleId is null) return unauthorizedResult;

        var role = await _roleRepository.GetRoleWithPermissionsAsync(auth.User.RoleId);

        if (auth.User.DepartmentId is null) return unauthorizedResult;

        var department = await _departmentRepository.GetAsync(auth.User.DepartmentId);

        List<Claim> claims = new List<Claim>();

        var token = _jwtService.Encode(getUserClaims(auth, role, department));

        var response = new AuthResponse(token, auth.User.NameAr , auth.User.NameEn);

        return new Result<AuthResponse>(OK, response);
    }

    private List<Claim> getUserClaims(Auth auth,Role role,Department department)
    {
        var claims = new List<Claim>
        {
            new Claim("UserId", auth.User.Id.ToString()),
            new Claim("UserEmail", auth.User.Email),
            new Claim("Role", role.Code.ToString()),
            new Claim("RoleCode", role.Code.ToString()),
            new Claim("RoleId", role.Id.ToString()),
            new Claim("RoleName", role.NameAr.ToString()),
            new Claim("DepartemntId", auth.User.DepartmentId.ToString()),
            new Claim("Departemnt", department.Code.ToString()),
            new Claim("DepartemntName", department.NameAr.ToString()),
            new Claim("UserName", auth.Login),
            new Claim("NameAr", auth.User.NameAr),
            new Claim("NameEn", auth.User.NameEn),
        };

        // Serialize permissions list to JSON and add it as a single claim
        var permissionNames = role.Permissions.Select(p => p.Code).ToList(); // Assuming "Name" is the permission's property you want
        var permissionsString = string.Join(",", permissionNames);

        claims.Add(new Claim("Permissions", permissionsString));


        return claims;
    }
}
