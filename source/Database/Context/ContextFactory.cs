using TMS.Application.Common;
using TMS.Database.Common;
using TMS.Database.Interceptors;

namespace TMS.Database;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        const string connectionString = "Server=.;Database=TMS;Trusted_Connection=True;TrustServerCertificate=True;";

        return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options , new NoMediator(), new AuditableEntitySaveChangesInterceptor(ICurrentUserService.NoCurrentService));
    }
}
