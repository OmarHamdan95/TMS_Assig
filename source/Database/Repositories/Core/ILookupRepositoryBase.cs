using AjKpi.Domain.Common;

namespace AjKpi.Database;

public interface ILookupRepositoryBase<T> : IRepository<T> where T : LookupBase
{
    Task<ProjectionType> GetModelAsync<ProjectionType>(long id);

    Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters);

    Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>();
    public void DeleteEntity(object key);
    Task DeleteEntityAsync(object key);

    Task<IEnumerable<ProjectionType>> AutoComplate<ProjectionType>(string? lookupCode , string? text);
}
