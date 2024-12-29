using AjKpi.Domain;
using AjKpi.Domain.MarkarEntity;
using AjKpi.Database.Common;
using Mapster;
using Microsoft.IdentityModel.Tokens;

namespace AjKpi.Database;

public class RepositoryBase<T> : EFRepository<T> ,IRepositoryBase<T>  where T : BaseAuditableEntity , IAggregateRoot
{
    private readonly Context _context;
    public RepositoryBase(Context context) : base(context)
    {
        _context = context;
    }

    public async Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters) => await Queryable
        .ProjectToType<ProjectionType>().GridAsync(
        parameters);

    public async Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>() => await Queryable.ProjectToType<ProjectionType>().ToListAsync();

    public async Task<ProjectionType> GetModelAsync<ProjectionType>(long id) =>  await Queryable
        .Where(entity => entity.Id == id).ProjectToType<ProjectionType>().SingleOrDefaultAsync();

    public void DeleteEntity(object key)
    {
        T entity = _context.Set<T>().Find(key);
        if ((object) entity == null)
            return;

        entity.IsDeleted = true;
        this._context.Entry<T>(entity).State = EntityState.Detached;
        this._context.Update<T>(entity);
    }

    public Task DeleteEntityAsync(object key) => Task.Run((Action)(() => this.DeleteEntity(key)));

}



