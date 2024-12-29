namespace AjKpi.Database;

public interface ISystemMenuRepository : IRepository<SystemMenu>
{
    Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>(string moduleCode);
}
