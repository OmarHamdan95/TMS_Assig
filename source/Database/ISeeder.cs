using Microsoft.Extensions.Configuration;
using Task = System.Threading.Tasks.Task;

namespace TMS.Database;

public interface ISeeder
{
    Task SeedAsync(Context context, IConfiguration configuration);
}
