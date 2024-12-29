
namespace AjKpi.Web;

public static class EndPointExtension
{
    public static void RegisterEndPoints(this IEndpointRouteBuilder routes)
    {
        routes.RegisterAuthEndPoints();
        routes.RegisterAttachmentEndpoints();
       // routes.RegisterDynamicFieldEndPoints();
        routes.RegisterUserEndpoints();
        routes.RegisterLookupEndpoints();
        routes.RegisterLookupValueEndpoints();
        routes.RegisterDepartmentEndpoints();
        routes.RegisterSystemMenuEndpoints();
        routes.RegisterRoleEndpoints();
        routes.RegisterPermissionEndpoints();
        routes.RegisterSeedersEndpoints();
        routes.RegisterReqeustEndpoints();
        routes.RegisterKpiEndpoints();
        routes.RegisterDashboardEndpoints();
    }




}
