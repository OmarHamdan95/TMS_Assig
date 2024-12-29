using AjKpi.Domain;
using AjKpi.Domain.MarkarEntity;
using AjKpi.Domain.Common;

namespace AjKpi.Database;

public interface IRepositoryBase<T> :IRepository<T> where T : BaseAuditableEntity , IAggregateRoot
{
    Task<ProjectionType> GetModelAsync<ProjectionType>(long id);

    Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters);

    Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>();
    public void DeleteEntity(object key);
    Task DeleteEntityAsync(object key);

}


