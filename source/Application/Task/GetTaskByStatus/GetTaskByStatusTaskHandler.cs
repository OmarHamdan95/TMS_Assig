using Dapper;
using TMS.Application.Common;
using TMS.Database;
using TMS.Database.Repositories.Dapper;
using TMS.Model;
using static System.Net.HttpStatusCode;
using Task = TMS.Domain.Task;

namespace TMS.Application;

public sealed record GetTaskByStatusHandler : IRequestHandler<GetTaskByStatusRequest, Result<IEnumerable<TaskModelPRC>>>
{
    private readonly IDapperService _dapperService;
    private readonly ICurrentUserService _currentUserService;

    public GetTaskByStatusHandler(IDapperService dapperService, ICurrentUserService currentUserService) =>
        (_dapperService, _currentUserService) = (dapperService, currentUserService);

    public async Task<Result<IEnumerable<TaskModelPRC>>> Handle(GetTaskByStatusRequest request, CancellationToken cancellationToken)
    {

        long curentUserId = 0;
        long.TryParse(_currentUserService.UserId, out curentUserId);


        //if (_currentUserService.Role.ToString() == UserRole.Admin.ToString())

        var parameters = new DynamicParameters();
        parameters.Add("@Status", (int)request.status);
        parameters.Add("@UserId", curentUserId);
        parameters.Add("@IsAdmin", _currentUserService.Role.ToString() == UserRole.Admin.ToString() ? 1 : 0);



        var data =  await _dapperService.QueryAsync<TaskModelPRC>("GetTasksByStatus", parameters);


        return new Result<IEnumerable<TaskModelPRC>>(data is null ? NotFound : OK, data);
    }
}
