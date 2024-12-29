using AjKpi.Domain;

namespace AjKpi.Database;

public interface IAuthRepository : IRepository<Auth>
{
    Task DeleteByUserIdAsync(long userId);

    Task<Auth> GetByLoginAsync(string login);
}
