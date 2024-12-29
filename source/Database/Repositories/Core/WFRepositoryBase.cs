using AjKpi.Database.Constants;
using AjKpi.Domain.Common;
using AjKpi.Domain.MarkarEntity;
using Mapster;
using Microsoft.IdentityModel.Tokens;

namespace AjKpi.Database;

public class WFRepositoryBase<T> : EFRepository<T> ,IWFRepositoryBase<T>  where T : BaseEntity , IWorkfklow
{
    private readonly Context _context;
    public WFRepositoryBase(Context context) : base(context)
    {
        _context = context;
    }

    public async Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters) => await Queryable
        .ProjectToType<ProjectionType>().GridAsync(
            parameters);

    public async Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>() => await Queryable.ProjectToType<ProjectionType>().ToListAsync();

    public async Task<IEnumerable<ProjectionType>> ListAsyncByCode<ProjectionType>(string? code)
    {
        return await Queryable.Where(x => x.Code == code).ProjectToType<ProjectionType>().ToListAsync();
    }

    public async Task<IEnumerable<ProjectionType>> ListAsyncByCodes<ProjectionType>(string? codes)
    {
        var _codes = codes.IsNullOrEmpty() ? null : codes.Split(",").ToHashSet();

        return await Queryable.Where(x => _codes.Contains(x.Code)).ProjectToType<ProjectionType>().ToListAsync();
    }

    public async Task<ProjectionType> GetModelAsync<ProjectionType>(long id) =>  await Queryable
        .Where(entity => entity.Id == id).ProjectToType<ProjectionType>().SingleOrDefaultAsync();

    public async Task<IEnumerable<ProjectionType>> AutoComplate<ProjectionType>(string? text)
    {
        var query = Queryable;

        //var t = DateTime.Now.AddDays(1);
        //query = query.Where(_ => _.ValidTo.HasValue && _.ValidTo >= DateTime.Now);

        if (!text.IsNullOrEmpty())
            query = query.Where(_ => _.Code.Contains(text.Trim()));

        var result = await query.Take(DatabaseConstants.LookupPageSize)
            .ProjectToType<ProjectionType>().ToListAsync();

        return result;

    }

    // public void DeleteEntity(object key)
    // {
    //     T entity = _context.Set<T>().Find(key);
    //     if ((object) entity == null)
    //         return;
    //
    //     entity.IsDeleted = true;
    //     this._context.Entry<T>(entity).State = EntityState.Detached;
    //     this._context.Update<T>(entity);
    // }

    // public Task DeleteEntityAsync(object key) => Task.Run((Action)(() => this.DeleteEntity(key)));

}
