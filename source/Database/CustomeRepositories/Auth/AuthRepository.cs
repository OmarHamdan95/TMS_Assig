using AjKpi.Domain;

namespace AjKpi.Database;

public sealed class AuthRepository : EFRepository<Auth>, IAuthRepository
{
    public AuthRepository(Context context) : base(context) { }

    public Task DeleteByUserIdAsync(long userId) => DeleteAsync(entity => entity.User.Id == userId);

    public Task<Auth> GetByLoginAsync(string login) => Queryable.Include(_=> _.User).SingleOrDefaultAsync(entity => entity.Login == login);
}
