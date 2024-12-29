using AjKpi.Application.Common;
using AjKpi.Database.Common;
using AjKpi.Database.Interceptors;

namespace AjKpi.Database;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        const string connectionString = "Host=localhost; Port=5432; Database=AjKPI; Username=postgres; Password=Test@1234";

        return new Context(new DbContextOptionsBuilder<Context>().UseNpgsql(connectionString).Options , new NoMediator(), new AuditableEntitySaveChangesInterceptor(ICurrentUserService.NoCurrentService));
    }
}
