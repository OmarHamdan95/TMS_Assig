using TMS.Domain.Common;
using TMS.Domain;
using TMS.Domain.MarkarEntity;
using Task = System.Threading.Tasks.Task;

namespace TMS.Database;

public interface IRepositoryBase<T> :IRepository<T> where T : BaseAuditableEntity , IAggregateRoot
{
    Task<ProjectionType> GetModelAsync<ProjectionType>(long id);

    Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters);

    Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>();
    public void DeleteEntity(object key);
    Task DeleteEntityAsync(object key);

}


