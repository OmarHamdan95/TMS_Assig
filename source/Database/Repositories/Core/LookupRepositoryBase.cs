﻿using Mapster;
using Microsoft.IdentityModel.Tokens;
using TMS.Database.Constants;
using TMS.Domain.Common;
using Task = System.Threading.Tasks.Task;

namespace TMS.Database;

public class LookupRepositoryBase<T> : EFRepository<T> ,ILookupRepositoryBase<T>  where T : LookupBase
{
    private readonly Context _context;
    public LookupRepositoryBase(Context context) : base(context)
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


    /// <summary>
    /// It's For Handle Auto Complate Value From lookup Value
    /// </summary>
    /// <param name="lookupCode"></param>
    /// <param name="text"></param>
    /// <typeparam name="ProjectionType"></typeparam>
    /// <returns></returns>
    public async Task<IEnumerable<ProjectionType>> AutoComplate<ProjectionType>(string? lookupCode, string? text)
    {
        var query = Queryable.Where(entity => entity.Code.ToUpper() == lookupCode.ToUpper());

        //var t = DateTime.Now.AddDays(1);
        //query = query.Where(_ => _.ValidTo.HasValue && _.ValidTo >= DateTime.Now);

        if (!text.IsNullOrEmpty())
            query = query.Where(_ => _.NameEn.Contains(text.Trim()) || _.NameAr.Contains(text.Trim()));

       var result = await query.Where(entity => entity.Code == lookupCode).Take(DatabaseConstants.LookupPageSize)
            .ProjectToType<ProjectionType>().ToListAsync();

       return result;

    }


}
