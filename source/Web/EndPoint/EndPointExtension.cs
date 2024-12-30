
namespace TMS.Web;

public static class EndPointExtension
{
    public static void RegisterEndPoints(this IEndpointRouteBuilder routes)
    {
        routes.RegisterAuthEndPoints();
        routes.RegisterUserEndpoints();
        routes.RegisterLookupEndpoints();
        routes.RegisterLookupValueEndpoints();
        routes.RegisterSeedersEndpoints();
        routes.RegisterTaskEndpoints();
    }




}
