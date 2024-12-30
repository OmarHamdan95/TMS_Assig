using Microsoft.Extensions.Configuration;
using Task = System.Threading.Tasks.Task;

namespace TMS.Database.Seeders;

public class SeedersProvider(Context context, IConfiguration configuration)
{
    public async Task SeedAsync()
    {
        // Seeders (Note: order matters!) :
        await new UserSeeder().SeedAsync(context, configuration);
    }
}
