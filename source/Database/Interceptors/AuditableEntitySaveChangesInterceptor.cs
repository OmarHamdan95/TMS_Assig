using AjKpi.Application.Common;
using AjKpi.Domain.MarkarEntity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AjKpi.Database.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly ICurrentUserService _currentUserService;

    private readonly DateTime _curentDate;

    public AuditableEntitySaveChangesInterceptor(ICurrentUserService currentUserService) =>
        (_currentUserService, _curentDate) = (currentUserService, DateTime.Now);

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public virtual void UpdateEntities(DbContext? context)
    {
        if (context is null) return;

        foreach (var entity in context.ChangeTracker.Entries())
        {
            if (entity.Entity is IAuditable auditableEntity)
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        if (string.IsNullOrEmpty(auditableEntity.CreatedBy))
                            auditableEntity.CreatedBy = _currentUserService?.UserName ?? "Unknown";
                        if (auditableEntity.CreatedDate is null || auditableEntity.CreatedDate == DateTime.MinValue)
                            auditableEntity.CreatedDate = _curentDate;
                        break;

                    case EntityState.Modified:
                        if (string.IsNullOrEmpty(auditableEntity.ModifiedBy))
                            auditableEntity.ModifiedBy = _currentUserService?.UserName ?? "Unknown";
                        if (auditableEntity.ModifiedDate is null || auditableEntity.ModifiedDate == DateTime.MinValue)
                            auditableEntity.ModifiedDate = _curentDate;

                        entity.Property(nameof(IAuditable.CreatedBy)).IsModified = false;
                        entity.Property(nameof(IAuditable.CreatedDate)).IsModified = false;
                        break;
                }
            }

            if (entity.Entity is ISoftDeletable deletableEntity)
            {
                if (entity.State == EntityState.Deleted)
                {
                    entity.State = EntityState.Modified;
                    deletableEntity.IsDeleted = true;
                    deletableEntity.ModifiedBy = _currentUserService?.UserName ?? "Unknown";
                    if (deletableEntity.ModifiedDate is null)
                        deletableEntity.ModifiedDate = _curentDate;
                }
            }
        }
    }
}
