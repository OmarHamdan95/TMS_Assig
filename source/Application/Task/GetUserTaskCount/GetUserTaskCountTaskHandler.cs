using Dapper;
using TMS.Application.Common;
using TMS.Database;
using TMS.Database.Repositories.Dapper;
using TMS.Model;
using static System.Net.HttpStatusCode;
using Task = TMS.Domain.Task;

namespace TMS.Application;

public sealed record GetUserTaskCountHandler : IRequestHandler<GetUserTaskCountTaskRequest, Result<IEnumerable<TaskModelPRCCount>>>
{
    private readonly IDapperService _dapperService;

    public GetUserTaskCountHandler(IDapperService dapperService) =>
        (_dapperService) = (dapperService);

    public async Task<Result<IEnumerable<TaskModelPRCCount>>> Handle(GetUserTaskCountTaskRequest request, CancellationToken cancellationToken)
    {

        var parameters = new DynamicParameters();

        var data =  await _dapperService.QueryAsync<TaskModelPRCCount>("GetUserTaskCounts", parameters);


        return new Result<IEnumerable<TaskModelPRCCount>>(data is null ? NotFound : OK, data);
    }
}
