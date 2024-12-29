using System.Reflection;
using AjKpi.Database.Constants;
using AjKpi.Domain.Common;
using AjKpi.Database.Common;
using AjKpi.Database.Interceptors;
using AjKpi.Domain.MarkarEntity;
using MediatR;


namespace AjKpi.Database;

public sealed class Context : DbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public Context(DbContextOptions options, IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //System.Diagnostics.Debugger.Launch();
        var domainTypes = Assembly
            .GetAssembly(typeof(Domain._IAssemblyMark))
            .GetTypes()
            .Where(
                myType =>
                    (myType.IsClass) && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseEntity)) &&
                    !typeof(IWorkfklow).IsAssignableFrom(myType)
                //!myType.GetInterface(nameof(IWorkfklow))
            )
            .ToList();

        builder.ApplyConvention(domainTypes, DatabaseConstants.DB_SCHEMA_NAME);

        var WfdomainTypes = Assembly
            .GetAssembly(typeof(Domain._IAssemblyMark))
            .GetTypes()
            .Where(
                myType =>
                    (myType.IsClass) && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseEntity)) &&
                    typeof(IWorkfklow).IsAssignableFrom(myType))
            .ToList();

        builder.ApplyConvention(WfdomainTypes, DatabaseConstants.DB_WfSCHEMA_NAME);


        foreach (var entity in builder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                //if (entity.Name == nameof(Auth))

                property.SetColumnName(property.Name.ToUpperUnderscoreColumnName());
            }
        }

        builder.ApplyConfigurationsFromAssembly(typeof(_IAssemblyMark).Assembly);

        //builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly).Seed();
    }


    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     base.OnConfiguring(optionsBuilder);
    // }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        //base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseLazyLoadingProxies(false);
        //optionsBuilder.AddInterceptors(new AuditableEntitySaveChangesInterceptor(""));
        //base on
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new CancellationToken())
    {
        await _mediator.DispatchDomainEvents(this);
        ApplayAudit(cancellationToken);
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public void ApplayAudit(CancellationToken cancellationToken = default)
    {
        foreach (var entity in ChangeTracker.Entries())
        {
            if (entity.Entity is BaseAuditableEntity auditableEntity)
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        if (string.IsNullOrEmpty(auditableEntity.CreatedBy))
                            auditableEntity.CreatedBy = "";

                        if (auditableEntity.CreatedDate is null || auditableEntity.CreatedDate == DateTime.MinValue)
                            auditableEntity.CreatedDate = DateTime.Now;

                        break;

                    case EntityState.Modified:
                        if (string.IsNullOrEmpty(auditableEntity.ModifiedBy))
                            auditableEntity.ModifiedBy = "";

                        if (auditableEntity.ModifiedDate is null || auditableEntity.ModifiedDate == DateTime.MinValue)
                            auditableEntity.ModifiedDate = DateTime.Now;

                        break;
                }
            }
        }
    }
}
