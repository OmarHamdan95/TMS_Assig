using Microsoft.Extensions.Configuration;

namespace AjKpi.Database.Seeders;

public class SeedersProvider(Context context, IConfiguration configuration)
{
    public async Task SeedAsync()
    {
        // Seeders (Note: order matters!) :
        await new DepartmentSeeder().SeedAsync(context, configuration);
        await new RoleSeeder().SeedAsync(context, configuration);
        await new PermissionSeeder().SeedAsync(context, configuration);
        await new LookupSeeder().SeedAsync(context, configuration);
        await new UserSeeder().SeedAsync(context, configuration);
        await new SystemMenueSeeder().SeedAsync(context, configuration);
        await new RequestTypesSeeder().SeedAsync(context, configuration);
    }
}
