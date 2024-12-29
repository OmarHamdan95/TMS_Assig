using AjKpi.Database.Constants;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using System.Security;

namespace AjKpi.Database;

public class PermissionRepository : EFRepository<Permission> , IPermissionRepository
{
    private readonly Context _context;
    public PermissionRepository(Context context) : base(context)
    {
        _context = context;
    }


    public async Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters) =>
        await Queryable
        .ProjectToType<ProjectionType>().GridAsync(
        parameters);

    public async Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>() => await Queryable.ProjectToType<ProjectionType>().ToListAsync();

    public async Task<ProjectionType> GetModelAsync<ProjectionType>(long id) =>  await Queryable
        .Where(entity => entity.Id == id).ProjectToType<ProjectionType>().SingleOrDefaultAsync();


    public void DeleteEntity(object key)
    {
        Permission entity = _context.Set<Permission>().Find(key);
        if ((object) entity == null)
            return;

        entity.IsDeleted = true;
        this._context.Entry<Permission>(entity).State = EntityState.Detached;
        this._context.Update<Permission>(entity);
    }

    public Task DeleteEntityAsync(object key) => Task.Run((Action)(() => this.DeleteEntity(key)));




}
