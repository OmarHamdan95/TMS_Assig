using AjKpi.Domain.Common;
using AjKpi.Domain.MarkarEntity;

namespace AjKpi.Database;

public interface IWFRepositoryBase<T> : IRepository<T> where T : BaseEntity ,  IWorkfklow
{
    Task<ProjectionType> GetModelAsync<ProjectionType>(long id);

    Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters);

    Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>();
    Task<IEnumerable<ProjectionType>> ListAsyncByCode<ProjectionType>(string? code);
    Task<IEnumerable<ProjectionType>> ListAsyncByCodes<ProjectionType>(string? codes);
    Task<IEnumerable<ProjectionType>> AutoComplate<ProjectionType>( string? text);

    // public void DeleteEntity(object key);
    // Task DeleteEntityAsync(object key);
}
