using AjKpi.Database.Constants;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AjKpi.Database;

public class SystemMenuRepository :EFRepository<SystemMenu> , ISystemMenuRepository
{
    private readonly Context _context;

    public SystemMenuRepository(Context context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProjectionType>> ListModelAsync<ProjectionType>(string moduleCode)
    {
        
        return await Queryable
            .Where(x => x.ModuleCode == moduleCode) 
            .ProjectToType<ProjectionType>() 
            .ToListAsync(); 
    }

}
