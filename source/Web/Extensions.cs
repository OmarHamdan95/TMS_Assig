using Mapster;
using Microsoft.OpenApi.Models;
using StackExchange.Profiling.Storage;
using TMS.Database.Seeders;
using TMS.Domain;
using TMS.Model;
using TMS.Web.Handler.Authorization;

namespace TMS.Web;

public static class Extensions
{
    public static void ConfigureMapster(this IApplicationBuilder builder)
    {
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        TypeAdapterConfig.GlobalSettings.Default.MaxDepth(3);
    }

    public static void AddProfiler(this IServiceCollection service)
    {
        service.AddMiniProfiler(option =>
        {
            option.RouteBasePath = "/api/profiler";
            option.ShowControls = true;
            option.PopupShowTrivial = true;
            option.StackMaxLength = 1000;
            ((option.Storage as MemoryCacheStorage)!).CacheDuration = TimeSpan.FromMinutes(60);
            option.SqlFormatter = new StackExchange.Profiling.SqlFormatters.SqlServerFormatter();
        }).AddEntityFramework();
    }

    public static void AddSwagger(this IServiceCollection service)
    {
        service.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "TMSWebAPI", Version = "v1" });

            options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    public static void AddSeederProvider(this IServiceCollection service)
    {
        service.AddScoped<SeedersProvider>();
    }

    public static void AddAuthPolicy(this IServiceCollection service)
    {
        service.AddAuthorization(options =>
        {
            options.AddPolicy("RegUser", policy =>
                policy.Requirements.Add(new PermissionRequirement("RegUser")));

            options.AddPolicy("MUser", policy =>
                policy.Requirements.Add(new PermissionRequirement("Admin")));
        });
    }
}


