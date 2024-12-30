using TMS.Domain;
using TMS.Model;

namespace TMS.Database;

public interface IUserRepository : IRepository<User>
{
    Task<UserModel> GetModelAsync(long id);

    Task<Grid<UserModel>> GridAsync(GridParameters parameters);

    Task<IEnumerable<UserModel>> ListModelAsync();
}
