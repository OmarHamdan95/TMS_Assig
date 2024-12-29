using AjKpi.Database.Constants;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AjKpi.Database;

public class RoleRepository :EFRepository<Role> ,IRoleRepository
{
    private readonly Context _context;

    public RoleRepository(Context context) : base(context)
    {
        _context = context;
    }


    public async Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters) => await Queryable
   .ProjectToType<ProjectionType>().GridAsync(
   parameters);

    public async Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>() => await Queryable.ProjectToType<ProjectionType>().ToListAsync();

    public async Task<ProjectionType> GetModelAsync<ProjectionType>(long id) => await Queryable
        .Where(entity => entity.Id == id).ProjectToType<ProjectionType>().SingleOrDefaultAsync();


    public void DeleteEntity(object key)
    {
        Department entity = _context.Set<Department>().Find(key);
        if ((object)entity == null)
            return;

        entity.IsDeleted = true;
        this._context.Entry<Department>(entity).State = EntityState.Detached;
        this._context.Update<Department>(entity);
    }

    public Task DeleteEntityAsync(object key) => Task.Run((Action)(() => this.DeleteEntity(key)));



    public async Task<IEnumerable<ProjectionType>> AutoComplate<ProjectionType>( string? text , long? parentId)
    {
        var query = Queryable.Where(entity => !entity.IsDeleted);

        //var t = DateTime.Now.AddDays(1);
        //query = query.Where(_ => _.ValidTo.HasValue && _.ValidTo >= DateTime.Now);

        if (!text.IsNullOrEmpty())
            query = query.Where(_ => _.NameEn.Contains(text.Trim()) || _.NameAr.Contains(text.Trim()));

        if(parentId.HasValue && parentId != 0)
            query = query.Where(_ => _.DepartmentId == parentId);

        var result = await query.Take(DatabaseConstants.LookupPageSize)
            .ProjectToType<ProjectionType>().ToListAsync();

        return result;

    }

    // public override


    public async Task<Role> GetRoleWithPermissionsAsync(long? id)
    {
        return await Queryable.Include(x=> x.Permissions)
            .SingleOrDefaultAsync(role => role.Id == id); // Find the Role by ID
    }
}
