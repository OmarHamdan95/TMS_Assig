using AjKpi.Database.Seeders;

namespace AjKpi.Web;

public static class SeadersEndPoint
{
    public static void RegisterSeedersEndpoints(this IEndpointRouteBuilder routes)
    {
        var seeder = routes.MapGroup("/api/seeder").RequireAuthorization().WithTags(nameof(SeadersEndPoint));

        seeder.MapPost("",
            [AllowAnonymous]  async (SeedersProvider _seedersProvider) =>
            {
                await _seedersProvider.SeedAsync();
                return Results.Ok();
            });

        seeder.MapGet("",
            [AllowAnonymous]  async (SeedersProvider _seedersProvider) =>
            {
                await _seedersProvider.SeedAsync();
                return Results.Ok();
            });
    }
}
