namespace AjKpi.Database;

public interface IRoleRepository: IRepository<Role>
{

    Task<ProjectionType> GetModelAsync<ProjectionType>(long id);

    Task<Grid<ProjectionType>> GridAsync<ProjectionType>(GridParameters parameters);

    Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>();
    public void DeleteEntity(object key);
    Task DeleteEntityAsync(object key);

    Task<IEnumerable<ProjectionType>> AutoComplate<ProjectionType>( string? text ,  long? parentId);

    Task<Role> GetRoleWithPermissionsAsync(long? id);
}
