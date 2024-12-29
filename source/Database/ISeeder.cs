using Microsoft.Extensions.Configuration;

namespace AjKpi.Database;

public interface ISeeder
{
    Task SeedAsync(Context context, IConfiguration configuration);
}
