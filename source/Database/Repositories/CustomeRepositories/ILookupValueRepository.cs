using TMS.Domain;
using Task = System.Threading.Tasks.Task;
namespace TMS.Database;

public interface ILookupValueRepository : IRepository<LookupValue>
{
    Task<ProjectionType> GetModelAsync<ProjectionType>(long id);

    Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters);

    Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>();
    public void DeleteEntity(object key);
    Task DeleteEntityAsync(object key);

    Task<IEnumerable<ProjectionType>> AutoComplate<ProjectionType>(string? lookupCode , string? text);
}
