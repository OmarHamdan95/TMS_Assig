using System.Data;
using Mapster;
using Microsoft.Data.SqlClient;
using TMS.Domain;
using TMS.Model;

namespace TMS.Database;

public sealed class UserRepository : EFRepository<User>, IUserRepository
{
    public Context Context { get; }
    public UserRepository(Context context) : base(context) { Context = context; }

    public static Expression<Func<User, UserModel>> Model => entity => new UserModel
    {
        Id = entity.Id,
        NameAr = entity.NameAr,
        NameEn = entity.NameEn,
        Email = entity.Email,
        Status = entity.Status,
        MobileNumber = entity.MobileNumber,
        // Department = entity.Department.Adapt<LookupValueModel>(),
        // Role = entity.Role.Adapt<LookupValueModel>(),
        // DepartmentId = entity.DepartmentId,
        // RoleId = entity.RoleId,
        UserName = entity.UserName,
        Role = entity.Role

        //Username = entity.

        //Role = entity.
    };

    public Task<UserModel> GetModelAsync(long id) => Queryable.Where(entity => entity.Id == id).Select(Model).SingleOrDefaultAsync();

    public Task<Grid<UserModel>> GridAsync(GridParameters parameters) => Queryable.Select(Model).GridAsync(parameters);

    public async Task<IEnumerable<UserModel>> ListModelAsync() => await Queryable.Select(Model).ToListAsync();

}
