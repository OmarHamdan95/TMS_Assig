using AjKpi.Database.Constants;
using Mapster;
using Microsoft.IdentityModel.Tokens;

namespace AjKpi.Database;

public class LookupValueRepository : EFRepository<LookupValue> ,ILookupValueRepository
{
    private readonly Context _context;
    public LookupValueRepository(Context context) : base(context)
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
        LookupValue entity = _context.Set<LookupValue>().Find(key);
        if ((object) entity == null)
            return;

        entity.IsDeleted = true;
        this._context.Entry<LookupValue>(entity).State = EntityState.Detached;
        this._context.Update<LookupValue>(entity);
    }

    public Task DeleteEntityAsync(object key) => Task.Run((Action)(() => this.DeleteEntity(key)));

    /// <summary>
    /// It's For Handle Auto Complate Value From lookup Value
    /// </summary>
    /// <param name="lookupCode"></param>
    /// <param name="text"></param>
    /// <typeparam name="ProjectionType"></typeparam>
    /// <returns></returns>
    public async Task<IEnumerable<ProjectionType>> AutoComplate<ProjectionType>(string? lookupCode, string? text)
    {
        var query = Queryable.Where(entity => entity.Lookup.Code.ToUpper() == lookupCode.ToUpper());

        //var t = DateTime.Now.AddDays(1);
        //query = query.Where(_ => _.ValidTo.HasValue && _.ValidTo >= DateTime.Now);

        if (!text.IsNullOrEmpty())
            query = query.Where(_ => _.NameEn.Contains(text.Trim()) || _.NameAr.Contains(text.Trim()));

       var result = await query.Take(DatabaseConstants.LookupPageSize)
            .ProjectToType<ProjectionType>().ToListAsync();

       return result;

    }



}
