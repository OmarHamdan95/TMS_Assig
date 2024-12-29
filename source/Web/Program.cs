using System.Reflection;
using AjKpi.Application.Common;
using AjKpi.Database.Interceptors;
using AjKpi.Domain;
using AjKpi.Web.Handler.Authorization;
using AjKpi.Web.Services;
using FluentValidation;
using Shared.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder();

// Configure JSON serialization options with custom DateTime converter
// builder.Services.Configure<JsonOptions>(options =>
// {
//     options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter("dd/MM/yyyy"));
// });



builder.Host.UseSerilog();

builder.Services.AddResponseCompression();
builder.Services.AddJsonStringLocalizer();
builder.Services.AddHashService();
builder.Services.AddJwtService();
builder.Services.AddAuthorization().AddAuthentication().AddJwtBearer();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(typeof(AjKpi.Application._IAssemblyMark).Assembly));

//builder.Services.AddScoped(typeof(IWFRepositoryBase<>), typeof(WFRepositoryBase<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork<Context>>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddScoped<AuditableEntitySaveChangesInterceptor>();


builder.Services.AddDbContext<Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(Context))));

builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

builder.Services.AddAuthPolicy();

builder.Services.AddSingleton<IAuthorizationHandler, PermissionHandler>();


builder.Services.AddSeederProvider();


builder.Services.AddClassesMatchingInterfaces(nameof(AjKpi));
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddProfiler();

//builder.Services.Configure<JsonOptions>(options => options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter("dd/MM/yyyy")));


builder.Services.AddSingleton<JsonSerializerSettings>(provider =>
{
    var settings = new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        DateTimeZoneHandling = DateTimeZoneHandling.Local,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        DateFormatString = "dd/MM/yyyy",
    };

    // Uncomment if you have a custom DateTime converter
    settings.Converters.Add(new JsonDateTimeConverter("dd/MM/yyyy"));

    return settings;
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.DateFormatString ="dd/MM/yyyy";
    //options.SerializerSettings.Converters.Add(new DateTimeConverter(Configuration["HourFormatString"]));
});





builder.Services.AddHttpContextAccessor();



var application = builder.Build();

application.UseException();
application.UseHsts().UseHttpsRedirection();
application.UseLocalization("en", "ar");
application.UseResponseCompression();
application.UseStaticFiles();
application.UseSwagger().UseSwaggerUI();
application.UseMiniProfiler();
application.UseRouting();
application.MapControllers();

application.ConfigureMapster();

application.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});

application.UseAuthentication();
application.UseAuthorization();

application.RegisterEndPoints();

//application.UseMiddleware<PermissionMiddleware>();


application.Run();
