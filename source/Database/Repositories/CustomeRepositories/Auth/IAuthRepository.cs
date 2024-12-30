using TMS.Domain;
using Task = System.Threading.Tasks.Task;

namespace TMS.Database;

public interface IAuthRepository : IRepository<Auth>
{
    Task DeleteByUserIdAsync(long userId);

    Task<Auth> GetByLoginAsync(string login);
}
